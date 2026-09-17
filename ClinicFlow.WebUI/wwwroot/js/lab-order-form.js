$(document).ready(function () {

    const $container = $('#items-container');
    const $labTest = $('#labTestId');
    const $status = $('#status');
    const $empty = $('#items-empty');

    const selectTestMessage =
        selectTest ??
        'Please select a laboratory test first.';

    // Initialize Select2
    $labTest.select2({
        width: '100%',
        placeholder: $labTest.find('option:first').text()
    });

    $('#add-item').on('click', function () {

        const labTestId = $labTest.val();

        // No test selected
        if (!labTestId) {
            //showToast(selectTestMessage, 'warning');
            toastr.warning(selectTestMessage);
            $labTest.select2('open');
            return;
        }

        const labTestText =
            $labTest.find('option:selected').text().trim();

        const status = $status.val();
        const statusText =
            $status.find('option:selected').text().trim();

        addItem(
            labTestId,
            labTestText,
            status,
            statusText
        );
    });

    function addItem(
        labTestId,
        labTestText,
        status,
        statusText
    ) {
        const index =
            $container.children('.lab-test-item-row').length;

        const row = `
            <tr class="lab-test-item-row"
                data-item-id="">

                <td>
                    <span class="item-lab-test-name">
                        ${escapeHtml(labTestText)}
                    </span>

                    <input type="hidden"
                           name="Items.Index"
                           value="${index}" />

                    <input type="hidden"
                           class="item-id-input"
                           name="Items[${index}].Id"
                           value="0" />

                    <input type="hidden"
                           class="item-lab-test-id-input"
                           name="Items[${index}].LabTestId"
                           value="${escapeHtml(labTestId)}" />
                </td>

                <td>
                    <span class="badge ${getStatusCssClass(status)}">
                        ${escapeHtml(statusText)}
                    </span>

                    <input type="hidden"
                           class="item-status-input"
                           name="Items[${index}].Status"
                           value="${escapeHtml(status)}" />
                </td>

                <td class="text-center">
                    <button type="button"
                            class="btn btn-sm btn-outline-danger remove-item"
                            title="${escapeHtml(removeText)}">
                        <i class="fa fa-trash"></i>
                    </button>
                </td>
            </tr>
        `;

        $container.append(row);

        // Disable the selected test
        disableSelectedTest(labTestId);

        clearItemInputs();
        reindexItems();
    }

    // Remove item
    $container.on('click', '.remove-item', function () {

        const $row = $(this).closest('.lab-test-item-row');

        const labTestId =
            $row.find('.item-lab-test-id-input').val();

        // Enable the test again
        enableTest(labTestId);

        $row.remove();

        reindexItems();
    });

    function disableSelectedTest(labTestId) {

        $labTest
            .find(`option[value="${escapeSelector(labTestId)}"]`)
            .prop('disabled', true);

        $labTest.val(null).trigger('change');
    }

    function enableTest(labTestId) {

        $labTest
            .find(`option[value="${escapeSelector(labTestId)}"]`)
            .prop('disabled', false);

        $labTest.trigger('change');
    }

    function reindexItems() {

        $container
            .children('.lab-test-item-row')
            .each(function (index) {

                const $row = $(this);

                $row.find('input[name="Items.Index"]')
                    .val(index);

                $row.find('.item-id-input')
                    .attr('name', `Items[${index}].Id`);

                $row.find('.item-lab-test-id-input')
                    .attr('name', `Items[${index}].LabTestId`);

                $row.find('.item-status-input')
                    .attr('name', `Items[${index}].Status`);
            });

        updateItemsState();
    }

    function updateItemsState() {

        const hasItems =
            $container.children('.lab-test-item-row').length > 0;

        $empty.toggleClass('d-none', hasItems);
    }

    function clearItemInputs() {

        $labTest.val(null).trigger('change');

        $status
            .val($status.find('option:first').val())
            .trigger('change');
    }

    function getStatusCssClass(status) {

        switch (parseInt(status)) {

            case 1:
                return 'bg-secondary';

            case 2:
                return 'bg-info text-dark';

            case 3:
                return 'bg-warning text-dark';

            case 4:
                return 'bg-success';

            case 5:
                return 'bg-danger';

            default:
                return 'bg-secondary';
        }
    }

    function escapeSelector(value) {
        return String(value).replace(
            /([ #;&,.+*~':"!^$[\]()=>|/@])/g,
            '\\$1'
        );
    }

    function escapeHtml(value) {
        return $('<div>')
            .text(value ?? '')
            .html();
    }

    /*
     * Important:
     * Handle existing items when editing.
     */
    function initializeExistingItems() {

        $container
            .children('.lab-test-item-row')
            .each(function () {

                const labTestId =
                    $(this)
                        .find('.item-lab-test-id-input')
                        .val();

                if (labTestId) {
                    disableSelectedTest(labTestId);
                }
            });

        reindexItems();
    }

    initializeExistingItems();
});