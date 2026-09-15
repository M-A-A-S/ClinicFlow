$(document).ready(function () {

    const $container = $('#parameters-container');
    const $empty = $('#parameters-empty');

    // =========================================================
    // Add Parameter
    // =========================================================

    $('#add-parameter').on('click', function () {

        const nameEn = $('#parameterNameEn').val().trim();
        const nameAr = $('#parameterNameAr').val().trim();
        const unit = $('#parameterUnit').val().trim();
        const normalRange = $('#parameterNormalRange').val().trim();
        const isActive = $('#parameterIsActive').is(':checked');

        if (!nameEn) {
            $('#parameterNameEn').focus();
            return;
        }

        const index =
            $container.children('.lab-test-parameter-row').length;

        const row = `
            <tr class="lab-test-parameter-row"
                data-parameter-id="">

                <!-- NameEn -->
                <td>

                    ${escapeHtml(nameEn)}

                    <input type="hidden"
                           name="Parameters.Index"
                           value="${index}" />

                    <input type="hidden"
                           class="parameter-id-input"
                           name="Parameters[${index}].Id"
                           value="0" />

                    <input type="hidden"
                           class="parameter-name-en-input"
                           name="Parameters[${index}].NameEn"
                           value="${escapeHtml(nameEn)}" />

                </td>


                <!-- NameAr -->
                <td>

                    ${escapeHtml(nameAr)}

                    <input type="hidden"
                           class="parameter-name-ar-input"
                           name="Parameters[${index}].NameAr"
                           value="${escapeHtml(nameAr)}" />

                </td>


                <!-- Unit -->
                <td>

                    ${escapeHtml(unit)}

                    <input type="hidden"
                           class="parameter-unit-input"
                           name="Parameters[${index}].Unit"
                           value="${escapeHtml(unit)}" />

                </td>


                <!-- NormalRange -->
                <td>

                    ${escapeHtml(normalRange)}

                    <input type="hidden"
                           class="parameter-normal-range-input"
                           name="Parameters[${index}].NormalRange"
                           value="${escapeHtml(normalRange)}" />

                </td>


                <!-- IsActive -->
                <td>

                    <span class="parameter-is-active badge ${isActive ? 'bg-success' : 'bg-danger'
            }">

                        ${
            isActive
                ? activeText
                : inactiveText
}

                    </span>

                    <input type="hidden"
                           class="parameter-is-active-input"
                           name="Parameters[${index}].IsActive"
                           value="${isActive}" />

                </td>


                <!-- DisplayOrder -->
                <td class="text-center">

                    <span class="parameter-display-order">
                        ${index + 1}
                    </span>

                    <input type="hidden"
                           class="parameter-display-order-input"
                           name="Parameters[${index}].DisplayOrder"
                           value="${index + 1}" />

                </td>


                <!-- Remove -->
                <td class="text-center">

                    <button type="button"
                            class="btn btn-sm btn-outline-danger remove-parameter"
                            title="@Localizer["Remove"]">

                        <i class="fa fa-trash"></i>

                    </button>

                </td>

            </tr>
        `;

        $container.append(row);

        clearParameterInputs();

        reindexParameters();
    });


    // =========================================================
    // Remove Parameter
    // =========================================================

    $container.on('click', '.remove-parameter', function () {

        $(this)
            .closest('.lab-test-parameter-row')
            .remove();

        reindexParameters();
    });


    // =========================================================
    // Reindex Parameters
    // =========================================================

    function reindexParameters() {

        $container
            .children('.lab-test-parameter-row')
            .each(function (index) {

                const $row = $(this);

                // Index
                $row.find('input[name="Parameters.Index"]')
                    .val(index);

                // Id
                $row.find('.parameter-id-input')
                    .attr(
                        'name',
                        `Parameters[${index}].Id`
                    );

                // NameEn
                $row.find('.parameter-name-en-input')
                    .attr(
                        'name',
                        `Parameters[${index}].NameEn`
                    );

                // NameAr
                $row.find('.parameter-name-ar-input')
                    .attr(
                        'name',
                        `Parameters[${index}].NameAr`
                    );

                // Unit
                $row.find('.parameter-unit-input')
                    .attr(
                        'name',
                        `Parameters[${index}].Unit`
                    );

                // NormalRange
                $row.find('.parameter-normal-range-input')
                    .attr(
                        'name',
                        `Parameters[${index}].NormalRange`
                    );

                // IsActive
                $row.find('.parameter-is-active-input')
                    .attr(
                        'name',
                        `Parameters[${index}].IsActive`
                    );

                // DisplayOrder
                const displayOrder = index + 1;

                $row.find('.parameter-display-order')
                    .text(displayOrder);

                $row.find('.parameter-display-order-input')
                    .attr(
                        'name',
                        `Parameters[${index}].DisplayOrder`
                    )
                    .val(displayOrder);

            });

        updateParametersState();
    }


    // =========================================================
    // Empty State
    // =========================================================

    function updateParametersState() {

        const hasParameters =
            $container.children('.lab-test-parameter-row').length > 0;

        $empty.toggleClass('d-none', hasParameters);
    }


    // =========================================================
    // Clear Inputs
    // =========================================================

    function clearParameterInputs() {

        $('#parameterNameEn').val('');
        $('#parameterNameAr').val('');
        $('#parameterUnit').val('');
        $('#parameterNormalRange').val('');
        $('#parameterIsActive').prop('checked', true);

        $('#parameterNameEn').focus();
    }


    // =========================================================
    // HTML Encoding
    // =========================================================

    function escapeHtml(value) {

        return $('<div>')
            .text(value ?? '')
            .html();
    }


    // =========================================================
    // Initial Load
    // =========================================================

    reindexParameters();

});