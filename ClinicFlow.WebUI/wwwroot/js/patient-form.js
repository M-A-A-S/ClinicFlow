let patientAllergyIndex = 0;
let patientChronicConditionIndex = 0;


/* ============================================================
   Utility
   ============================================================ */

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


function formatDate(value) {

    if (!value) {
        return "";
    }

    const date = new Date(value);

    if (isNaN(date.getTime())) {
        return value;
    }

    const year = date.getFullYear();
    const month = String(date.getMonth() + 1).padStart(2, "0");
    const day = String(date.getDate()).padStart(2, "0");

    return `${year}-${month}-${day}`;
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
function getTodayDate() {

    const today = new Date();

    const year =
        today.getFullYear();

    const month =
        String(
            today.getMonth() + 1
        ).padStart(2, "0");

    const day =
        String(
            today.getDate()
        ).padStart(2, "0");

    return `${year}-${month}-${day}`;
}

/* ============================================================
   Allergies
   ============================================================ */

function buildAllergyRow(allergy) {

    const index = patientAllergyIndex++;

    const allergyText =
        getSelectText(
            "allergyId",
            allergy.allergyId
        );

    return `

        <tr class="patient-allergy-row"
            data-allergy-id="${allergy.allergyId}">

            <td>

                ${escapeHtml(allergyText)}

                <input
                    type="hidden"
                    name="PatientAllergies.Index"
                    value="${index}" />

                <input
                    type="hidden"
                    name="PatientAllergies[${index}].Id"
                    value="${allergy.id || 0}" />

                <input
                    type="hidden"
                    name="PatientAllergies[${index}].AllergyId"
                    value="${allergy.allergyId}" />

            </td>


            <td>

                ${escapeHtml(allergy.notes)}

                <input
                    type="hidden"
                    name="PatientAllergies[${index}].Notes"
                    value="${escapeHtml(allergy.notes)}" />

            </td>


            <td>

                ${escapeHtml(allergy.identifiedAt)}

                <input
                    type="hidden"
                    name="PatientAllergies[${index}].IdentifiedAt"
                    value="${escapeHtml(allergy.identifiedAt)}" />

            </td>


            <td class="text-center">

                <button
                    type="button"
                    class="btn btn-sm btn-outline-danger remove-allergy">

                    <i class="fa fa-trash"></i>

                </button>

            </td>

        </tr>

    `;
}


function addAllergy() {

    const select = document.getElementById("allergyId");

    if (!select || !select.value) {
        toastr.warning(
            window.patientFormMessages.selectAllergy
        );
        return;
    }


    const allergy = {

        id: 0,

        allergyId: select.value,

        allergyText:
            select.options[select.selectedIndex].text,

        notes:
            document.getElementById("allergyNotes").value,

        identifiedAt:
            document.getElementById("allergyIdentifiedAt").value
    };


    document
        .getElementById("allergies-container")
        .insertAdjacentHTML(
            "beforeend",
            buildAllergyRow(allergy)
    );

    /*
    * Disable selected option
    */

    select.options[
        select.selectedIndex
    ].disabled = true;


    // Clear inputs

    select.value = "";

    document.getElementById("allergyNotes").value = "";

    document.getElementById("allergyIdentifiedAt").value = getTodayDate();
}


/* ============================================================
   Chronic Conditions
   ============================================================ */

function buildChronicConditionRow(condition) {

    const index = patientChronicConditionIndex++;

    const conditionText =
        getSelectText(
            "chronicConditionId",
            condition.chronicConditionId
        );

    return `

        <tr class="patient-chronic-condition-row"
            data-chronic-condition-id="${condition.chronicConditionId}">

            <td>

                ${escapeHtml(conditionText)}

                <input
                    type="hidden"
                    name="PatientChronicConditions.Index"
                    value="${index}" />

                <input
                    type="hidden"
                    name="PatientChronicConditions[${index}].Id"
                    value="${condition.id || 0}" />

                <input
                    type="hidden"
                    name="PatientChronicConditions[${index}].ChronicConditionId"
                    value="${condition.chronicConditionId}" />

            </td>


            <td>

                ${escapeHtml(condition.notes)}

                <input
                    type="hidden"
                    name="PatientChronicConditions[${index}].Notes"
                    value="${escapeHtml(condition.notes)}" />

            </td>


            <td>

                ${escapeHtml(condition.diagnosedAt)}

                <input
                    type="hidden"
                    name="PatientChronicConditions[${index}].DiagnosedAt"
                    value="${escapeHtml(condition.diagnosedAt)}" />

            </td>


            <td class="text-center">

                <button
                    type="button"
                    class="btn btn-sm btn-outline-danger remove-chronic-condition">

                    <i class="fa fa-trash"></i>

                </button>

            </td>

        </tr>

    `;
}


function addChronicCondition() {

    const select =
        document.getElementById("chronicConditionId");


    if (!select || !select.value) {
        toastr.warning(
            window.patientFormMessages.selectChronicCondition
        );
        return;
    }


    const condition = {

        id: 0,

        chronicConditionId:
            select.value,

        conditionText:
            select.options[select.selectedIndex].text,

        notes:
            document.getElementById(
                "chronicConditionNotes"
            ).value,

        diagnosedAt:
            document.getElementById(
                "chronicConditionDiagnosedAt"
            ).value
    };


    document
        .getElementById("chronic-conditions-container")
        .insertAdjacentHTML(
            "beforeend",
            buildChronicConditionRow(condition)
    );

    /*
    * Disable selected option
    */

    select.options[
        select.selectedIndex
    ].disabled = true;


    // Clear inputs

    select.value = "";

    document.getElementById(
        "chronicConditionNotes"
    ).value = "";

    document.getElementById(
        "chronicConditionDiagnosedAt"
    ).value = getTodayDate();
}


/* ============================================================
   Remove rows
   ============================================================ */

document.addEventListener("click", function (event) {

    const button =
        event.target.closest(".remove-allergy");

    if (!button) {
        return;
    }

    const row =
        button.closest(".patient-allergy-row");

    if (!row) {
        return;
    }

    const allergyId =
        row.dataset.allergyId;

    /*
    * Enable option again
    */

    const select =
        document.getElementById(
            "allergyId"
        );


    const option =
        Array.from(select.options)
            .find(
                x => x.value == allergyId
            );


    if (option) {
        option.disabled = false;
    }

    /*
        * Remove row
        */

    row.remove();

});

document.addEventListener("click", function (event) {

    const button =
        event.target.closest(".remove-chronic-condition");

    if (!button) {
        return;
    }

    const row =
        button.closest(
            ".patient-chronic-condition-row"
        );

    if (!row) {
        return;
    }

    const conditionId =
        row.dataset.chronicConditionId;

    /*
    * Enable option again
    */

    const select =
        document.getElementById(
            "chronicConditionId"
        );


    const option =
        Array.from(select.options)
            .find(
                x => x.value == conditionId
            );


    if (option) {
        option.disabled = false;
    }

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

    const addAllergyButton =
        document.getElementById("add-allergy");

    if (addAllergyButton) {

        addAllergyButton.addEventListener(
            "click",
            addAllergy
        );

    }


    const addChronicButton =
        document.getElementById(
            "add-chronic-condition"
        );

    if (addChronicButton) {

        addChronicButton.addEventListener(
            "click",
            addChronicCondition
        );

    }


    // Existing allergies

    if (
        Array.isArray(window.patientExistingAllergies)
    ) {

        window.patientExistingAllergies
            .forEach(function (allergy) {

                document
                    .getElementById("allergies-container")
                    .insertAdjacentHTML(
                        "beforeend",
                        buildAllergyRow({

                            id: allergy.id,

                            allergyId:
                                allergy.allergyId,

                            allergyText:
                                allergy.allergyText,

                            notes:
                                allergy.notes,

                            identifiedAt:
                                formatDate(
                                    allergy.identifiedAt
                                )
                        })
                );

                /*
         * Disable existing allergy
         */

                disableSelectOption(
                    "allergyId",
                    allergy.allergyId
                );

            });

    }


    // Existing chronic conditions

    if (
        Array.isArray(
            window.patientExistingChronicConditions
        )
    ) {

        window.patientExistingChronicConditions
            .forEach(function (condition) {

                document
                    .getElementById(
                        "chronic-conditions-container"
                    )
                    .insertAdjacentHTML(
                        "beforeend",
                        buildChronicConditionRow({

                            id: condition.id,

                            chronicConditionId:
                                condition.chronicConditionId,

                            conditionText:
                                condition.conditionText,

                            notes:
                                condition.notes,

                            diagnosedAt:
                                formatDate(
                                    condition.diagnosedAt
                                )
                        })
                );

                disableSelectOption(
                    "chronicConditionId",
                    condition.chronicConditionId
                );

            });

    }

});