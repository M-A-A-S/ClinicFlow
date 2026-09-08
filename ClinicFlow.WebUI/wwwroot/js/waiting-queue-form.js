$(document).ready(function () {

    if (!window.waitingQueueData) {
        return;
    }


    initializeWaitingQueueDoctorFilter();
});



/* =========================================================
   Appointment
   Clinic -> Doctor
   Supports:
   - Create
   - Edit
   ========================================================= */

function initializeWaitingQueueDoctorFilter() {

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
                    window.waitingQueueLocalization.selectClinicFirst,
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
                window.waitingQueueLocalization.selectDoctor,
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
            window.waitingQueueData.clinicDoctors
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
        window.waitingQueueData.doctors
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

