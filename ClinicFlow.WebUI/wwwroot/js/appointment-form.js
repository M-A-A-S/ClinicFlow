$(document).ready(function () {

    if (window.appointmentData) {

        initializeAppointmentDoctorFilter();

        initializeAppointmentDateTime();

    }

});



/* =========================================================
   Appointment
   Clinic -> Doctor
   ========================================================= */

function initializeAppointmentDoctorFilter() {

    const clinicSelect = $('#clinicId');
    const doctorSelect = $('#doctorId');

    if (!clinicSelect.length || !doctorSelect.length) {
        return;
    }

    // Initial state
    if (!clinicSelect.val()) {

        doctorSelect.empty();

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
    }

    clinicSelect.on('change', function () {

        const clinicId = $(this).val();

        doctorSelect.empty();

        // No clinic selected
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

        // Clinic selected
        doctorSelect.append(
            new Option(
                window.appointmentLocalization.selectDoctor,
                ''
            )
        );

        doctorSelect.prop('disabled', false);

        const doctorIds = window.appointmentData.clinicDoctors
            .filter(function (item) {

                return String(item.clinicId) ===
                    String(clinicId);

            })
            .map(function (item) {

                return String(item.doctorId);

            });

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

        doctorSelect
            .val('')
            .trigger('change');
    });
}


/* =========================================================
   Appointment
   StartAt -> EndAt + 30 minutes
   ========================================================= */

function initializeAppointmentDateTime() {

    const startAt = $('#startAt');
    const endAt = $('#endAt');

    if (!startAt.length || !endAt.length) {
        return;
    }

    startAt.on('change', function () {

        const startValue = $(this).val();

        // If StartAt is empty, clear EndAt
        if (!startValue) {
            endAt.val('');
            return;

        }

        const startDate = new Date(startValue);

        // Invalid date
        if (isNaN(startDate.getTime())) {
            return;
        }

        // Add 30 minutes
        startDate.setMinutes(
            startDate.getMinutes() + 30
        );

        // Format for datetime-local
        const year =
            startDate.getFullYear();

        const month =
            String(
                startDate.getMonth() + 1
            ).padStart(2, '0');

        const day =
            String(
                startDate.getDate()
            ).padStart(2, '0');

        const hours =
            String(
                startDate.getHours()
            ).padStart(2, '0');

        const minutes =
            String(
                startDate.getMinutes()
            ).padStart(2, '0');


        const endValue =
            `${year}-${month}-${day}T${hours}:${minutes}`;


        // Set EndAt
        endAt.val(endValue);


        // Trigger change for validation
        endAt.trigger('change');

    });

}