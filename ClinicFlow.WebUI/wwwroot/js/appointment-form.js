$(document).ready(function () {

    /*
     * Appointment page only
     */
    if (!window.appointmentData) {
        return;
    }


    initializeAppointmentDoctorFilter();

    initializeAppointmentDateTime();

});



/* =========================================================
   Appointment
   Clinic -> Doctor
   Supports:
   - Create
   - Edit
   ========================================================= */

function initializeAppointmentDoctorFilter() {

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
                    window.appointmentLocalization.selectClinicFirst,
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
                window.appointmentLocalization.selectDoctor,
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
            window.appointmentData.clinicDoctors

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
        window.appointmentData.doctors

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
   Appointment
   StartAt -> EndAt + 30 Minutes
   Supports:
   - Create
   - Edit
   ========================================================= */

function initializeAppointmentDateTime() {

    const startAt = $('#startAt');
    const endAt = $('#endAt');


    if (!startAt.length || !endAt.length) {
        return;
    }


    /*
     * Calculate EndAt whenever StartAt changes.
     */
    startAt.on('change', function () {

        const startValue = $(this).val();


        /*
         * StartAt is empty
         */
        if (!startValue) {

            endAt.val('');

            endAt.trigger('change');

            return;
        }


        /*
         * datetime-local format:
         *
         * 2026-09-07T15:30
         */
        const parts = startValue.split('T');


        if (parts.length !== 2) {
            return;
        }


        const datePart = parts[0];
        const timePart = parts[1];


        const dateParts = datePart.split('-');
        const timeParts = timePart.split(':');


        if (
            dateParts.length !== 3 ||
            timeParts.length < 2
        ) {
            return;
        }


        let year =
            parseInt(dateParts[0], 10);

        let month =
            parseInt(dateParts[1], 10);

        let day =
            parseInt(dateParts[2], 10);

        let hours =
            parseInt(timeParts[0], 10);

        let minutes =
            parseInt(timeParts[1], 10);


        /*
         * Validate numbers
         */
        if (
            isNaN(year) ||
            isNaN(month) ||
            isNaN(day) ||
            isNaN(hours) ||
            isNaN(minutes)
        ) {
            return;
        }


        /*
         * Add 30 minutes
         */
        minutes += 30;


        /*
         * Handle minute overflow
         *
         * 15:45 + 30
         * = 16:15
         */
        if (minutes >= 60) {

            hours +=
                Math.floor(minutes / 60);

            minutes =
                minutes % 60;

        }


        /*
         * Handle day overflow
         *
         * 23:45 + 30
         * = next day 00:15
         */
        if (hours >= 24) {

            const date =
                new Date(
                    year,
                    month - 1,
                    day
                );


            date.setDate(
                date.getDate() +
                Math.floor(hours / 24)
            );


            year =
                date.getFullYear();

            month =
                date.getMonth() + 1;

            day =
                date.getDate();

            hours =
                hours % 24;

        }


        /*
         * Format:
         *
         * yyyy-MM-ddTHH:mm
         */
        const endValue =
            `${year}-${String(month).padStart(2, '0')}-${String(day).padStart(2, '0')}` +
            `T${String(hours).padStart(2, '0')}:${String(minutes).padStart(2, '0')}`;


        /*
         * Set EndAt
         */
        endAt.val(endValue);


        /*
         * Trigger validation/change
         */
        endAt.trigger('change');

    });

}