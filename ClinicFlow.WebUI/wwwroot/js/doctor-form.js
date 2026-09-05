let doctorSpecialtyIndex = 0;


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

/* ============================================================
   Specialties
   ============================================================ */

function buildSpecialtyRow(specialty) {

    const index = doctorSpecialtyIndex++;

    const specialtyText =
        getSelectText(
            "specialtyId",
            specialty.specialtyId
        );

    return `

        <tr class="doctor-specialty-row"
            data-specialty-id="${specialty.specialtyId}">

            <td>

                ${escapeHtml(specialtyText)}

                <input
                    type="hidden"
                    name="DoctorSpecialties.Index"
                    value="${index}" />

                <input
                    type="hidden"
                    name="DoctorSpecialties[${index}].Id"
                    value="${specialty.id || 0}" />

                <input
                    type="hidden"
                    name="DoctorSpecialties[${index}].SpecialtyId"
                    value="${specialty.specialtyId}" />

            </td>

            <td class="text-center">

                <button
                    type="button"
                    class="btn btn-sm btn-outline-danger remove-specialty">

                    <i class="fa fa-trash"></i>

                </button>

            </td>

        </tr>

    `;
}


function addSpecialty() {

    const select = document.getElementById("specialtyId");

    if (!select || !select.value) {
        toastr.warning(
            window.doctorFormMessages.selectSpecialty
        );
        return;
    }


    const specialty = {

        id: 0,

        specialtyId: select.value,

        //specialtyText:
        //    select.options[select.selectedIndex].text,
    };


    document
        .getElementById("specialties-container")
        .insertAdjacentHTML(
            "beforeend",
            buildSpecialtyRow(specialty)
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
        event.target.closest(".remove-specialty");

    if (!button) {
        return;
    }

    const row =
        button.closest(".doctor-specialty-row");

    if (!row) {
        return;
    }

    const specialtyId =
        row.dataset.specialtyId;

    /*
    * Enable option again
    */

    const select =
        document.getElementById(
            "specialtyId"
        );


    const option =
        Array.from(select.options)
            .find(
                x => x.value == specialtyId
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

    const addSpecialtyButton =
        document.getElementById("add-specialty");

    if (addSpecialtyButton) {

        addSpecialtyButton.addEventListener(
            "click",
            addSpecialty
        );

    }


    // Existing specialties

    if (
        Array.isArray(window.doctorExistingSpecialties)
    ) {

        window.doctorExistingSpecialties
            .forEach(function (specialty) {

                document
                    .getElementById("specialties-container")
                    .insertAdjacentHTML(
                        "beforeend",
                        buildSpecialtyRow({

                            id: specialty.id,

                            specialtyId:
                                specialty.specialtyId,

                            specialtyText:
                                specialty.specialtyText,
                        })
                    );

                /*
         * Disable existing specialty
         */

                disableSelectOption(
                    "specialtyId",
                    specialty.specialtyId
                );

            });

    }

});