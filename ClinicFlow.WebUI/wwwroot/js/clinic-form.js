let clinicDoctorIndex = 0;


/* ============================================================
   Utility
   ============================================================ */

// escapeHtml('<script>alert("Hello")</script>') => &lt;script&gt;alert(&quot;Hello&quot;)&lt;/script&gt;
function escapeHtml(value) {

    if (value === null || value === undefined) {
        return "";
    }

    return String(value)
        .replace(/&/g, "&amp;")
        .replace(/</g, "&lt;")
        .replace(/>/g, "&gt;")
        .replace(/"/g, "&quot;")
        .replace(/'/g, "&#039;");
}

function getSelectText(selectId, value) {

    const select = document.getElementById(selectId);

    if (!select || !value) {
        return "";
    }

    const option =
        Array.from(select.options)
            .find(x => x.value == value);

    return option
        ? option.text
        : "";
}

function disableSelectOption(
    selectId,
    value
) {

    const select =
        document.getElementById(selectId);


    if (!select) {
        return;
    }

    const option =
        Array.from(select.options)
            .find(
                x => x.value == value
            );


    if (option) {
        option.disabled = true;
    }

}

function enableSelectOption(
    selectId,
    value
) {

    const select =
        document.getElementById(selectId);


    if (!select) {
        return;
    }

    const option =
        Array.from(select.options)
            .find(
                x => x.value == value
            );


    if (option) {
        option.disabled = false;
    }

}

/* ============================================================
   Specialties
   ============================================================ */

function buildClinicDoctorRow(clinicDoctor) {

    const index = clinicDoctorIndex++;

    const doctorText =
        getSelectText(
            "doctorId",
            clinicDoctor.doctorId
        );

    return `

        <tr class="clinic-doctor-row"
            data-doctor-id="${clinicDoctor.doctorId}">

            <td>

                ${escapeHtml(doctorText)}

                <input
                    type="hidden"
                    name="ClinicDoctors.Index"
                    value="${index}" />

                <input
                    type="hidden"
                    name="ClinicDoctors[${index}].Id"
                    value="${clinicDoctor.id || 0}" />

                <input
                    type="hidden"
                    name="ClinicDoctors[${index}].DoctorId"
                    value="${clinicDoctor.doctorId}" />

            </td>

            <td class="text-center">

                <button
                    type="button"
                    class="btn btn-sm btn-outline-danger remove-doctor">

                    <i class="fa fa-trash"></i>

                </button>

            </td>

        </tr>

    `;
}


function addDoctor() {

    const select = document.getElementById("doctorId");

    if (!select || !select.value) {
        toastr.warning(
            window.clinicFormMessages.selectDoctor
        );
        return;
    }


    const clinicDoctor = {

        id: 0,

        doctorId: select.value,

        //specialtyText:
        //    select.options[select.selectedIndex].text,
    };


    document
        .getElementById("doctors-container")
        .insertAdjacentHTML(
            "beforeend", // at the end of the container
            buildClinicDoctorRow(clinicDoctor)
        );

    /*
    * Disable selected option
    */

    select.options[
        select.selectedIndex
    ].disabled = true;


    // Clear inputs

    select.value = "";
}



/* ============================================================
   Remove rows
   ============================================================ */

document.addEventListener("click", function (event) {

    const button =
        event.target.closest(".remove-doctor");

    if (!button) {
        return;
    }

    const row =
        button.closest(".clinic-doctor-row");

    if (!row) {
        return;
    }

    const doctorId =
        row.dataset.doctorId;

    /*
    * Enable option again
    */
    enableSelectOption(
        "doctorId",
        doctorId
    );

    /*
        * Remove row
        */

    row.remove();

});


/* ============================================================
   Button events
   ============================================================ */

document.addEventListener("DOMContentLoaded", function () {

    // Add buttons

    const addDoctorButton =
        document.getElementById("add-doctor");

    if (addDoctorButton) {

        addDoctorButton.addEventListener(
            "click",
            addDoctor
        );

    }


    // Existing specialties

    if (
        Array.isArray(window.clinicExistingDoctors)
    ) {

        window.clinicExistingDoctors
            .forEach(function (clinicDoctor) {

                document
                    .getElementById("doctors-container")
                    .insertAdjacentHTML(
                        "beforeend",
                        buildClinicDoctorRow({

                            id: clinicDoctor.id,

                            doctorId:
                                clinicDoctor.doctorId,

                            specialtyText:
                                clinicDoctor.specialtyText,
                        })
                    );

                /*
         * Disable existing specialty
         */

                disableSelectOption(
                    "doctorId",
                    clinicDoctor.doctorId
                );

            });

    }

});