"use strict";

const VisitForm = {

    diagnosisIndex: 0,

    prescriptionItemIndex: 0,


    init() {

        this.initializeIndexes();

        this.registerEvents();

        this.calculateBMI();

        this.updateCompletedAt();

        this.updateDiagnosisEmptyState();

        this.updatePrescriptionEmptyState();

        this.initializeSelect2();

    },


    initializeIndexes() {

        const diagnosisRows =
            document.querySelectorAll(
                ".visit-diagnosis-row"
            );

        this.diagnosisIndex =
            diagnosisRows.length;


        const prescriptionRows =
            document.querySelectorAll(
                ".prescription-item-row"
            );

        this.prescriptionItemIndex =
            prescriptionRows.length;

    },


    registerEvents() {

        document
            .getElementById("add-diagnosis")
            ?.addEventListener(
                "click",
                () => this.addDiagnosis()
            );


        document
            .getElementById("add-prescription-item")
            ?.addEventListener(
                "click",
                () => this.addPrescriptionItem()
            );


        document
            .getElementById("weight")
            ?.addEventListener(
                "input",
                () => this.calculateBMI()
            );


        document
            .getElementById("height")
            ?.addEventListener(
                "input",
                () => this.calculateBMI()
            );


        document
            .getElementById("visitStatus")
            ?.addEventListener(
                "change",
                () => this.updateCompletedAt()
            );


        document.addEventListener(
            "click",
            event => {

                const diagnosisButton =
                    event.target.closest(
                        ".remove-diagnosis"
                    );

                if (diagnosisButton) {

                    this.removeDiagnosis(
                        diagnosisButton
                    );

                    return;
                }


                const prescriptionButton =
                    event.target.closest(
                        ".remove-prescription-item"
                    );

                if (prescriptionButton) {

                    this.removePrescriptionItem(
                        prescriptionButton
                    );
                }

            }
        );

    },


    initializeSelect2() {

        if (!window.jQuery) {
            return;
        }

        $(".select2").each(function () {

            if (!$(this).hasClass("select2-hidden-accessible")) {

                $(this).select2({
                    width: "100%"
                });

            }

        });

    },


    calculateBMI() {

        const weight =
            parseFloat(
                document.getElementById("weight")?.value
            );

        const height =
            parseFloat(
                document.getElementById("height")?.value
            );

        const bmi =
            document.getElementById("bmi");

        if (!bmi) {
            return;
        }

        if (
            !weight ||
            !height ||
            height <= 0
        ) {

            bmi.value = "";

            return;
        }

        const heightMeters =
            height / 100;

        const result =
            weight /
            (heightMeters * heightMeters);

        bmi.value =
            result.toFixed(2);

    },


    updateCompletedAt() {

        const status =
            document.getElementById(
                "visitStatus"
            );

        const container =
            document.getElementById(
                "completedAtContainer"
            );

        if (!status || !container) {
            return;
        }

        const completedStatus =
            container
                .closest("#visit-form")
                ?.dataset.completedStatus;

        if (
            completedStatus &&
            status.value === completedStatus
        ) {

            container.style.display = "";

        }
        else {

            container.style.display = "none";

        }

    },


    addDiagnosis() {

        const select =
            document.getElementById(
                "diagnosisId"
            );

        const notes =
            document.getElementById(
                "diagnosisNotes"
            );


        if (!select || !select.value) {

            this.warning(
                "PleaseSelectDiagnosis"
            );

            return;
        }


        if (
            this.isDiagnosisAlreadyAdded(
                select.value
            )
        ) {

            this.warning(
                "DuplicateDiagnosis"
            );

            return;
        }


        const diagnosisId =
            select.value;

        const diagnosisName =
            select.options[
                select.selectedIndex
            ]?.text ?? "";

        const diagnosisNotes =
            notes?.value.trim() ?? "";


        const index =
            this.diagnosisIndex++;


        const row = `

            <tr class="visit-diagnosis-row"
                data-diagnosis-id="${this.escapeHtml(diagnosisId)}">

                <td>

                    ${this.escapeHtml(diagnosisName)}

                    <input type="hidden"
                           name="VisitDiagnoses.Index"
                           value="${index}" />

                    <input type="hidden"
                           name="VisitDiagnoses[${index}].Id"
                           value="0" />

                    <input type="hidden"
                           name="VisitDiagnoses[${index}].DiagnosisId"
                           value="${this.escapeHtml(diagnosisId)}" />

                </td>

                <td>

                    ${this.escapeHtml(diagnosisNotes)}

                    <input type="hidden"
                           name="VisitDiagnoses[${index}].Notes"
                           value="${this.escapeHtml(diagnosisNotes)}" />

                </td>

                <td class="text-center">

                    <button type="button"
                            class="btn btn-sm btn-outline-danger remove-diagnosis">

                        <i class="fa fa-trash"></i>

                    </button>

                </td>

            </tr>

        `;


        document
            .getElementById(
                "diagnoses-container"
            )
            ?.insertAdjacentHTML(
                "beforeend",
                row
            );


        this.disableOption(
            "diagnosisId",
            diagnosisId
        );


        if (notes) {
            notes.value = "";
        }


        this.resetSelect(
            "diagnosisId"
        );


        this.updateDiagnosisEmptyState();

    },


    removeDiagnosis(button) {

        const row =
            button.closest(
                ".visit-diagnosis-row"
            );

        if (!row) {
            return;
        }


        const diagnosisId =
            row.dataset.diagnosisId;


        this.enableOption(
            "diagnosisId",
            diagnosisId
        );


        row.remove();


        this.updateDiagnosisEmptyState();

    },


    isDiagnosisAlreadyAdded(diagnosisId) {

        return document.querySelector(
            `.visit-diagnosis-row[data-diagnosis-id="${this.escapeSelector(diagnosisId)}"]`
        ) !== null;

    },


    updateDiagnosisEmptyState() {

        const container =
            document.getElementById(
                "diagnoses-container"
            );

        const empty =
            document.getElementById(
                "diagnosis-empty"
            );

        if (!container || !empty) {
            return;
        }

        empty.style.display =
            container.children.length === 0
                ? ""
                : "none";

    },


    addPrescriptionItem() {

        const medicine =
            document.getElementById(
                "medicineId"
            );

        if (!medicine || !medicine.value) {

            this.warning(
                "MedicineRequired"
            );

            return;
        }


        if (
            this.isMedicineAlreadyAdded(
                medicine.value
            )
        ) {

            this.warning(
                "MedicineAlreadyAdded"
            );

            return;
        }


        const dosage =
            document.getElementById(
                "dosage"
            )?.value.trim() ?? "";


        const frequency =
            document.getElementById(
                "frequency"
            )?.value.trim() ?? "";


        const duration =
            document.getElementById(
                "duration"
            )?.value.trim() ?? "";


        const quantity =
            document.getElementById(
                "quantity"
            )?.value ?? "";


        const instructions =
            document.getElementById(
                "instructions"
            )?.value.trim() ?? "";


        if (!dosage) {

            this.warning(
                "PrescriptionDosageRequired"
            );

            return;
        }


        if (!frequency) {

            this.warning(
                "PrescriptionFrequencyRequired"
            );

            return;
        }


        if (!duration) {

            this.warning(
                "PrescriptionDurationRequired"
            );

            return;
        }


        if (
            !quantity ||
            Number(quantity) <= 0
        ) {

            this.warning(
                "PrescriptionQuantityMustBeGreaterThanZero"
            );

            return;
        }


        const medicineId =
            medicine.value;

        const medicineName =
            medicine.options[
                medicine.selectedIndex
            ]?.text ?? "";


        const index =
            this.prescriptionItemIndex++;


        const row = `

            <tr class="prescription-item-row"
                data-medicine-id="${this.escapeHtml(medicineId)}">

                <td>

                    ${this.escapeHtml(medicineName)}

                    <input type="hidden"
                           name="Prescription.Items.Index"
                           value="${index}" />

                    <input type="hidden"
                           name="Prescription.Items[${index}].Id"
                           value="0" />

                    <input type="hidden"
                           name="Prescription.Items[${index}].MedicineId"
                           value="${this.escapeHtml(medicineId)}" />

                </td>

                <td>

                    ${this.escapeHtml(dosage)}

                    <input type="hidden"
                           name="Prescription.Items[${index}].Dosage"
                           value="${this.escapeHtml(dosage)}" />

                </td>

                <td>

                    ${this.escapeHtml(frequency)}

                    <input type="hidden"
                           name="Prescription.Items[${index}].Frequency"
                           value="${this.escapeHtml(frequency)}" />

                </td>

                <td>

                    ${this.escapeHtml(duration)}

                    <input type="hidden"
                           name="Prescription.Items[${index}].Duration"
                           value="${this.escapeHtml(duration)}" />

                </td>

                <td>

                    ${this.escapeHtml(quantity)}

                    <input type="hidden"
                           name="Prescription.Items[${index}].Quantity"
                           value="${this.escapeHtml(quantity)}" />

                </td>

                <td>

                    ${this.escapeHtml(instructions)}

                    <input type="hidden"
                           name="Prescription.Items[${index}].Instructions"
                           value="${this.escapeHtml(instructions)}" />

                </td>

                <td class="text-center">

                    <button type="button"
                            class="btn btn-sm btn-outline-danger remove-prescription-item">

                        <i class="fa fa-trash"></i>

                    </button>

                </td>

            </tr>

        `;


        document
            .getElementById(
                "prescription-items-container"
            )
            ?.insertAdjacentHTML(
                "beforeend",
                row
            );


        this.disableOption(
            "medicineId",
            medicineId
        );


        this.clearPrescriptionInputs();

        this.resetSelect(
            "medicineId"
        );


        this.updatePrescriptionEmptyState();

    },


    removePrescriptionItem(button) {

        const row =
            button.closest(
                ".prescription-item-row"
            );

        if (!row) {
            return;
        }


        const medicineId =
            row.dataset.medicineId;


        this.enableOption(
            "medicineId",
            medicineId
        );


        row.remove();


        this.updatePrescriptionEmptyState();

    },


    isMedicineAlreadyAdded(medicineId) {

        return document.querySelector(
            `.prescription-item-row[data-medicine-id="${this.escapeSelector(medicineId)}"]`
        ) !== null;

    },


    updatePrescriptionEmptyState() {

        const container =
            document.getElementById(
                "prescription-items-container"
            );

        const empty =
            document.getElementById(
                "prescription-empty"
            );

        if (!container || !empty) {
            return;
        }

        empty.style.display =
            container.children.length === 0
                ? ""
                : "none";

    },


    clearPrescriptionInputs() {

        const ids = [

            "dosage",
            "frequency",
            "duration",
            "quantity",
            "instructions"

        ];


        ids.forEach(id => {

            const element =
                document.getElementById(id);

            if (element) {
                element.value = "";
            }

        });

    },


    resetSelect(id) {

        const select =
            document.getElementById(id);

        if (!select) {
            return;
        }


        select.value = "";


        if (
            window.jQuery &&
            $(select).hasClass("select2")
        ) {

            $(select).trigger("change");

        }

    },


    disableOption(id, value) {

        const select =
            document.getElementById(id);

        if (!select) {
            return;
        }


        const option =
            Array.from(
                select.options
            ).find(
                option =>
                    option.value == value
            );


        if (option) {
            option.disabled = true;
        }


        if (
            window.jQuery &&
            $(select).hasClass("select2")
        ) {

            $(select).trigger("change");

        }

    },


    enableOption(id, value) {

        const select =
            document.getElementById(id);

        if (!select) {
            return;
        }


        const option =
            Array.from(
                select.options
            ).find(
                option =>
                    option.value == value
            );


        if (option) {
            option.disabled = false;
        }


        if (
            window.jQuery &&
            $(select).hasClass("select2")
        ) {

            $(select).trigger("change");

        }

    },


    warning(key) {

        if (
            window.toastr &&
            typeof toastr.warning === "function"
        ) {

            toastr.warning(
                this.getMessage(key)
            );

            return;
        }

        alert(
            this.getMessage(key)
        );

    },


    getMessage(key) {

        const isArabic = document.documentElement.lang === "ar";

        const messages = {

            PleaseSelectDiagnosis: {
                en: "Please select a diagnosis.",
                ar: "يرجى اختيار التشخيص."
            },

            DuplicateDiagnosis: {
                en: "This diagnosis has already been added.",
                ar: "تمت إضافة هذا التشخيص مسبقًا."
            },

            MedicineRequired: {
                en: "Medicine is required.",
                ar: "الدواء مطلوب."
            },

            MedicineAlreadyAdded: {
                en: "This medicine has already been added.",
                ar: "تمت إضافة هذا الدواء مسبقًا."
            },

            PrescriptionDosageRequired: {
                en: "Dosage is required.",
                ar: "الجرعة مطلوبة."
            },

            PrescriptionFrequencyRequired: {
                en: "Frequency is required.",
                ar: "تكرار تناول الدواء مطلوب."
            },

            PrescriptionDurationRequired: {
                en: "Duration is required.",
                ar: "مدة العلاج مطلوبة."
            },

            PrescriptionQuantityMustBeGreaterThanZero: {
                en: "Quantity must be greater than zero.",
                ar: "يجب أن تكون كمية الدواء أكبر من صفر."
            }

        };

        const message = messages[key];

        if (!message)
            return key;

        return isArabic ? message.ar : message.en;
    },


    escapeHtml(value) {

        if (
            value === null ||
            value === undefined
        ) {

            return "";

        }


        return String(value)
            .replace(/&/g, "&amp;")
            .replace(/</g, "&lt;")
            .replace(/>/g, "&gt;")
            .replace(/"/g, "&quot;")
            .replace(/'/g, "&#039;");

    },


    escapeSelector(value) {

        if (
            window.CSS &&
            CSS.escape
        ) {

            return CSS.escape(
                String(value)
            );

        }


        return String(value)
            .replace(
                /([!"#$%&'()*+,./:;<=>?@[\\\]^`{|}~])/g,
                "\\$1"
            );

    }

};


document.addEventListener(
    "DOMContentLoaded",
    function () {

        const form =
            document.getElementById(
                "visit-form"
            );

        if (!form) {
            return;
        }

        VisitForm.init();

    }
);


/////
$(document).ready(function () {

    if (!window.visitData) {
        return;
    }


    initializeVisitDoctorFilter();
});



/* =========================================================
   Appointment
   Clinic -> Doctor
   Supports:
   - Create
   - Edit
   ========================================================= */

function initializeVisitDoctorFilter() {

    const clinicSelect = $('#clinicId');
    const doctorSelect = $('#doctorId');


    if (!clinicSelect.length || !doctorSelect.length) {
        return;
    }

    /*
     * IMPORTANT:
     *
     * On Edit, asp-for="DoctorId" gives us the existing
     * doctor's ID before JavaScript modifies the select.
     *
     * On Create, this will normally be empty.
     */
    const initialDoctorId = doctorSelect.val();

    /*
     * Load doctors for selected clinic
     */
    function loadDoctors(clinicId, selectedDoctorId = '') {

        /*
         * Clear existing doctors
         */
        doctorSelect.empty();

        /*
         * No clinic selected
         */
        if (!clinicId) {

            doctorSelect.append(
                new Option(
                    window.visitLocalization.selectClinicFirst,
                    ''
                )
            );


            doctorSelect
                .prop('disabled', true)
                .val('')
                .trigger('change');

            return;
        }

        /*
         * Clinic selected
         */
        doctorSelect.append(
            new Option(
                window.visitLocalization.selectDoctor,
                ''
            )
        );


        /*
         * Enable Doctor
         */
        doctorSelect.prop('disabled', false);


        /*
         * Get doctor IDs assigned to this clinic
         */
        const doctorIds =
            window.visitData.clinicDoctors
                .filter(function (item) {
                    return String(item.clinicId) ===
                        String(clinicId);
                })
                .map(function (item) {
                    return String(item.doctorId);
                });


        /*
         * Add only doctors assigned to selected clinic
         */
        window.visitData.doctors
            .filter(function (doctor) {
                return doctorIds.includes(
                    String(doctor.id)
                );
            })
            .forEach(function (doctor) {
                doctorSelect.append(
                    new Option(
                        doctor.text,
                        doctor.id
                    )
                );
            });


        /*
         * EDIT MODE
         *
         * If the existing doctor belongs to the selected
         * clinic, keep it selected.
         */
        if (
            selectedDoctorId &&
            doctorIds.includes(String(selectedDoctorId))
        ) {

            doctorSelect
                .val(String(selectedDoctorId))
                .trigger('change');

        }
        else {

            /*
             * CREATE MODE
             *
             * Or doctor does not belong to selected clinic.
             */
            doctorSelect
                .val('')
                .trigger('change');

        }

    }


    /*
     * INITIAL PAGE LOAD
     *
     * Create:
     *   clinic = empty
     *   doctor = empty
     *
     * Edit:
     *   clinic = existing clinic
     *   doctor = existing doctor
     */
    loadDoctors(
        clinicSelect.val(),
        initialDoctorId
    );


    /*
     * CLINIC CHANGED
     */
    clinicSelect.on('change', function () {

        const clinicId = $(this).val();


        /*
         * IMPORTANT:
         *
         * We pass an empty doctor ID here.
         *
         * This means when the user changes clinic,
         * the previous doctor will NOT remain selected.
         */
        loadDoctors(
            clinicId,
            ''
        );

    });

}



/* =========================================================
Handle Model Binding For optional Visit Sections
========================================================= */

document.addEventListener("DOMContentLoaded", function () {
    initializeOptionalSections();
    initializeExistingSections();
    registerOptionalSectionEvents();
});


function initializeOptionalSections() {

    document.querySelectorAll(".optional-section").forEach(section => {
        disableSectionFields(section);
    });
}

function initializeExistingSections() {

    if (hasPrescription) {
        openOptionalSection("prescriptionSection");
        hideAddButton("prescriptionSection");
    }

    if (hasVitalSign) {
        openOptionalSection("vitalSignsSection");
        hideAddButton("vitalSignsSection");
    }

    if (hasDiagnoses) {
        openOptionalSection("diagnosesSection");
        hideAddButton("diagnosesSection");
    }
}


function registerOptionalSectionEvents() {

    document.querySelectorAll("[data-toggle-section]")
        .forEach(button => {

            button.addEventListener("click", function () {

                const sectionId = this.dataset.toggleSection;

                openOptionalSection(sectionId);
                hideAddButton(sectionId);
            });
        });


    document.querySelectorAll("[data-remove-section]")
        .forEach(button => {

            button.addEventListener("click", function () {

                const sectionId = this.dataset.removeSection;

                closeOptionalSection(sectionId);
                showAddButton(sectionId);
            });
        });
}


function openOptionalSection(sectionId) {

    const section = document.getElementById(sectionId);

    if (!section) {
        return;
    }

    section.classList.remove("d-none");

    enableSectionFields(section);
}


function closeOptionalSection(sectionId) {

    const section = document.getElementById(sectionId);

    if (!section) {
        return;
    }

    section.classList.add("d-none");

    disableSectionFields(section);
}


function enableSectionFields(section) {

    section.querySelectorAll("input, select, textarea")
        .forEach(input => {
            input.disabled = false;
        });
}


function disableSectionFields(section) {

    section.querySelectorAll("input, select, textarea")
        .forEach(input => {
            input.disabled = true;
        });
}


function hideAddButton(sectionId) {

    const button = document.querySelector(
        `[data-toggle-section="${sectionId}"]`
    );

    if (button) {
        button.classList.add("d-none");
    }
}


function showAddButton(sectionId) {

    const button = document.querySelector(
        `[data-toggle-section="${sectionId}"]`
    );

    if (button) {
        button.classList.remove("d-none");
    }
}