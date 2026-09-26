console.log('invoice-form.js loaded');

$(document).ready(function () {

    console.log('invoice page ready');

    const $itemType = $('#invoiceItemType');
    const $itemId = $('#invoiceItemId');

    const $paymentType = $('#invoicePaymentType');
    const $paymentMethod = $('#invoicePaymentMethod');

    initializeInvoice();
    bindItemEvents();
    bindPaymentEvents();

    bindInvoiceForm();

    function initializeInvoice() {

        initializeItems();
        initializePayments();

        updateItemsState();
        updatePaymentsState();

        updateInvoiceSummary();
    }

    // =========================================================
    // Invoice Items
    // =========================================================

    function bindItemEvents() {

        $itemType.on('change', function () {

            filterInvoiceItems(
                $(this).val()
            );
        });

        $('#invoiceItemQuantity, #invoiceItemUnitPrice')
            .on('input', function () {

             updateInvoiceItemTotal();
        });

        $('#add-item').on('click', function () {
            addInvoiceItem();
        });

        $('#items-container').on(
            'click',
            '.remove-item',
            function () {
                removeItem($(this));
                updateInvoiceSummary();
            }
        );

        $itemId.on('change', function () {

            updateInvoiceItemFromSelection();
        });
    }

    function updateInvoiceItemFromSelection() {

        const $option =
            $itemId.find('option:selected');

        const itemName =
            $option.text().trim();

        const unitPrice =
            parseFloat(
                $option.data('unit-price')
            ) || 0;

        $('#invoiceItemDescription')
            .val(itemName);

        $('#invoiceItemUnitPrice')
            .val(unitPrice.toFixed(2));

        updateInvoiceItemTotal();
    }

    function filterInvoiceItems(type) {

        clearInvoiceItems();

        if (!type) {
            return;
        }

        showInvoiceItems(type);
    }

    function clearInvoiceItems() {

        $itemId
            .val('')
            .find('option[data-item-type]')
            .hide();

        $itemId.prop('disabled', true);

        $('#invoiceItemDescription')
            .val('');

        $('#invoiceItemUnitPrice')
            .val('0.00');

        $('#invoiceItemTotal')
            .text('0.00');
    }

    function showInvoiceItems(type) {

        $itemId
            .find(`option[data-item-type="${type}"]`)
            .show();

        $itemId.prop('disabled', false);
    }

    function addInvoiceItem() {
        const data = getInvoiceItemData();

        if (!validateInvoiceItem(data)) {
            return;
        }

        if (invoiceItemExists(data.itemId)) {
            showInvoiceItemError(
                'This item has already been added.'
            );

            return;
        }

        addItem(data);

        updateInvoiceSummary();

        resetInvoiceItemModal();

        closeInvoiceItemModal();
    }

    function getInvoiceItemData() {

        const itemType = $itemType.val();

        const $typeOption = $itemType.find('option:selected');

        const itemTypeName = $typeOption.attr('data-display-name') || '';

        const $selectedItem =
            $itemId.find('option:selected');

        const itemId = $selectedItem.val();
        const itemName = $selectedItem.text().trim();

        console.log('itemId -> ', itemId)
        console.log('itemName -> ', itemName)

        const description =
            $('#invoiceItemDescription').val().trim();

        const quantity =
            parseFloat($('#invoiceItemQuantity').val()) || 0;

        const unitPrice =
            parseFloat($('#invoiceItemUnitPrice').val()) || 0;

        const total =
            quantity * unitPrice;

        return {
            itemType: itemType,
            itemTypeName,
            itemId: itemId,
            itemName: itemName,
            description: description,
            quantity: quantity,
            unitPrice: unitPrice,
            total: total
        };
    }

    function validateInvoiceItem(data) {
        if (!data.itemType) {

            showInvoiceItemError(
                invoiceMessages.selectItemType
            );

            return false;
        }

        if (!data.itemId) {

            showInvoiceItemError(
                invoiceMessages.selectItem
            );

            return false;
        }

        if (data.quantity <= 0) {

            showInvoiceItemError(
                invoiceMessages.quantityGreaterThanZero
            );

            return false;
        }

        if (data.unitPrice < 0) {

            showInvoiceItemError(
                invoiceMessages.unitPriceCannotBeNegative
            );

            return false;
        }

        return true;
    }

    function invoiceItemExists(itemId) {
        let exists = false;

        $('#items-container')
            .children('.invoice-item-row')
            .each(function () {

                const existingItemId =
                    $(this)
                        .find('.item-id-input')
                        .val();

                if (existingItemId === itemId) {

                    exists = true;

                    return false;
                }
            });

        return exists;
    }

    function showInvoiceItemError(message) {

        //alert(message);
        toastr.warning(message);
    }

    function addItem(data) {

        const $container = $('#items-container');

        const index =
            $container.children('.invoice-item-row').length;

        const row = createItemRow(index, data);

        $container.append(row);

        updateItemsState();
    }

    function removeItem($button) {

        const $row =
            $button.closest('.invoice-item-row');

        $row.remove();

        reindexItems();
        updateItemsState();
    }

    function createItemRow(index, data) {

        return `
            <tr class="invoice-item-row"  data-item-id="${escapeHtml(data.itemId)}">

                <td>

                <input type="hidden"
                       name="Items.Index"
                       value="${index}" />

                <input type="hidden"
                       name="Items[${index}].Id"
                       value="0"
                       class="item-id-input" />

                <input type="hidden"
                       name="Items[${index}].ReferenceId"
                       value="${data.itemId}"
                       class="item-reference-id-input" />


                <input type="hidden"
                       name="Items[${index}].ItemType"
                       value="${escapeHtml(data.itemType)}"
                       class="item-type-input" />

                <span>
                    ${escapeHtml(data.itemTypeName)}
                </span>

            </td>

                <td>

                <span>
                    ${escapeHtml(
                        data.description || data.itemName
                    )}
                </span>

                <input type="hidden"
                       name="Items[${index}].Description"
                       value="${escapeHtml(
                        data.description || data.itemName
                    )}"
                       class="item-description-input" />

            </td>

                <td>

                <span>
                    ${data.quantity}
                </span>

                <input type="hidden"
                       name="Items[${index}].Quantity"
                       value="${data.quantity}"
                       class="item-quantity-input" />

            </td>

                <td>

                <span>
                    ${data.unitPrice.toFixed(2)}
                </span>

                <input type="hidden"
                       name="Items[${index}].UnitPrice"
                       value="${data.unitPrice}"
                       class="item-unitPrice-input" />

            </td>

                <<td>

                <span>
                    ${data.total.toFixed(2)}
                </span>

                <input type="hidden"
                       name="Items[${index}].Total"
                       value="${data.total}"
                       class="item-total-input" />

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
    }

    function updateInvoiceItemTotal() {
        const quantity =
            parseFloat(
                $('#invoiceItemQuantity').val()
            ) || 0;

        const unitPrice =
            parseFloat(
                $('#invoiceItemUnitPrice').val()
            ) || 0;

        const total =
            quantity * unitPrice;

        $('#invoiceItemTotal')
            .text(total.toFixed(2));
    }

    function resetInvoiceItemModal() {
        $itemType.val('');

        $itemId
            .val('')
            .prop('disabled', true);

        $itemId
            .find('option[data-item-type]')
            .hide();

        $('#invoiceItemDescription')
            .val('');

        $('#invoiceItemQuantity')
            .val('1');

        $('#invoiceItemUnitPrice')
            .val('0');

        $('#invoiceItemTotal')
            .text('0.00');
    }

    function closeInvoiceItemModal() {
        const modalElement =
            document.getElementById(
                'invoiceItemModal'
            );

        const modal =
            bootstrap.Modal.getInstance(
                modalElement
            );

        if (modal) {
            modal.hide();
        }
    }

    function reindexItems() {

        $('#items-container')
            .children('.invoice-item-row')
            .each(function (index) {

                const $row = $(this);

                $row.find('input[name="Items.Index"]')
                    .val(index);

                updateItemInputName(
                    $row,
                    '.item-id-input',
                    `Items[${index}].Id`
                );

                updateItemInputName(
                    $row,
                    '.item-reference-id-input',
                    `Items[${index}].ReferenceId`
                );

                updateItemInputName(
                    $row,
                    '.item-type-input',
                    `Items[${index}].ItemType`
                );

                updateItemInputName(
                    $row,
                    '.item-description-input',
                    `Items[${index}].Description`
                );

                updateItemInputName(
                    $row,
                    '.item-quantity-input',
                    `Items[${index}].Quantity`
                );

                updateItemInputName(
                    $row,
                    '.item-unit-price-input',
                    `Items[${index}].UnitPrice`
                );

                updateItemInputName(
                    $row,
                    '.item-total-input',
                    `Items[${index}].Total`
                );
            });
    }

    function updateItemInputName(
        $row,
        selector,
        name
    ) {

        $row.find(selector)
            .attr('name', name);
    }

    function updateItemsState() {

        const $container = $('#items-container');
        const $empty = $('#items-empty');

        const hasItems =
            $container.children('.invoice-item-row').length > 0;

        $empty.toggleClass(
            'd-none',
            hasItems
        );
    }

    function initializeItems() {

        initializeInvoiceItemSelect();
        reindexItems();
    }

    function initializeInvoiceItemSelect() {

        $itemId
            .find('option[data-item-type]')
            .hide();

        $itemId
            .val('')
            .prop('disabled', true);
    }


    // =========================================================
    // Invoice Payments
    // =========================================================

    function bindPaymentEvents() {

        $('#add-payment').on('click', function () {
            addInvoicePayment();
        });

        $('#payments-container').on(
            'click',
            '.remove-payment',
            function () {
                removePayment($(this));
                updateInvoiceSummary();
            }
        );
    }

    function addInvoicePayment() {
        const data =
            getInvoicePaymentData();

        if (!validateInvoicePayment(data)) {
            return;
        }

        if (invoicePaymentExists(data)) {

            showInvoicePaymentError(
                'This payment has already been added.'
            );

            return;
        }

        addPayment(data);

        updateInvoiceSummary();

        resetInvoicePaymentModal();

        closeInvoicePaymentModal();
    }

    function getInvoicePaymentData() {

        const $typeOption = $paymentType.find('option:selected');
        const $methodOption = $paymentMethod.find('option:selected');

        const type =
            $paymentType.val();
        const typeName = $typeOption.attr('data-display-name') || '';

        const paymentMethod =
            $paymentMethod.val();
        const paymentMethodName = $methodOption.text();

        const amount =
            parseFloat(
                $('#invoicePaymentAmount').val()
            ) || 0;

        const paymentDate =
            $('#invoicePaymentDate').val();

        const referenceNumber =
            $('#invoicePaymentReferenceNumber')
                .val()
                .trim();

        const notes =
            $('#invoicePaymentNotes')
                .val()
                .trim();

        return {
            type: type,
            typeName,
            paymentMethod: paymentMethod,
            paymentMethodName,
            amount: amount,
            paymentDate: paymentDate,
            referenceNumber: referenceNumber,
            notes: notes
        };
    }

    function validateInvoicePayment(data) {
        if (!data.type) {

            showInvoicePaymentError(
                invoiceMessages.selectPaymentType
            );

            return false;
        }

        if (!data.paymentMethod) {

            showInvoicePaymentError(
                invoiceMessages.selectPaymentMethod
            );

            return false;
        }

        if (data.amount <= 0) {

            showInvoicePaymentError(
                invoiceMessages.amountGreaterThanZero
            );

            return false;
        }

        if (!data.paymentDate) {

            showInvoicePaymentError(
                invoiceMessages.selectPaymentDate
            );

            return false;
        }

        if (data.type == 'Receipt') {
            const grandTotal =
                parseFloat($('#invoice-grand-total').text()) || 0;

            const paidAmount =
                getInvoicePaidAmount();

            const remainingAmount =
                grandTotal - paidAmount;

            if (data.amount > remainingAmount) {
                showInvoicePaymentError(
                    `${invoiceMessages.receiptGreaterThanRemaining} (${remainingAmount.toFixed(2)}).`
                );

                return false;
            }
        }

        return true;
    }

    function getInvoicePaidAmount() {
        let paidAmount = 0;

        $('#payments-container')
            .find('.invoice-payment-row')
            .each(function () {

                const type =
                    $(this).find('.payment-type-input').val();

                const amount =
                    parseFloat(
                        $(this).find('.payment-amount-input').val()
                    ) || 0;

                if (type === 'Receipt') {
                    paidAmount += amount;
                }

                if (type === 'Payment') {
                    paidAmount -= amount;
                }
            });

        return paidAmount;
    }

    function invoicePaymentExists(data) {
        let exists = false;

        $('#payments-container')
            .children('.invoice-payment-row')
            .each(function () {

                const $row = $(this);

                const existingType =
                    $row
                        .find('.payment-type-input')
                        .val();

                const existingMethod =
                    $row
                        .find('.payment-method-input')
                        .val();

                const existingAmount =
                    parseFloat(
                        $row
                            .find('.payment-amount-input')
                            .val()
                    ) || 0;

                const existingDate =
                    $row
                        .find('.payment-date-input')
                        .val();

                if (
                    existingType === data.type &&
                    existingMethod === data.paymentMethod &&
                    existingAmount === data.amount &&
                    existingDate === data.paymentDate
                ) {

                    exists = true;

                    return false;
                }
            });

        return exists;
    }

    function showInvoicePaymentError(message) {

        //alert(message);
        //console.log(message);
        toastr.warning(message);
    }

    function addPayment(data) {

        const $container = $('#payments-container');

        console.log("$container -> ", $container)

        const index =
            $container.children('.invoice-payment-row').length;

        const row =
            createPaymentRow(index, data);

        $container.append(row);

        updatePaymentsState();
    }

    function removePayment($button) {

        const $row =
            $button.closest('.invoice-payment-row');

        $row.remove();

        reindexPayments();
        updatePaymentsState();
    }

    function createPaymentRow(index, data) {

        return `
        <tr class="invoice-payment-row">

            <td>

                <input type="hidden"
                       name="Payments.Index"
                       value="${index}" />

                <input type="hidden"
                       name="Payments[${index}].Id"
                       value="0"
                       class="payment-id-input" />

                <span class="payment-type-text">
                    ${escapeHtml(data.typeName)}
                </span>

                <input type="hidden"
                       name="Payments[${index}].Type"
                       value="${escapeHtml(data.type)}"
                       class="payment-type-input" />

            </td>

            <td>

                <span class="payment-amount">
                    ${data.amount.toFixed(2)}
                </span>

                <input type="hidden"
                       name="Payments[${index}].Amount"
                       value="${data.amount}"
                       class="payment-amount-input" />

            </td>

            <td>

                <span class="payment-method-text">
                    ${escapeHtml(data.paymentMethodName)}
                </span>

                <input type="hidden"
                       name="Payments[${index}].PaymentMethodId"
                       value="${escapeHtml(data.paymentMethod)}"
                       class="payment-method-input" />

            </td>

            <td>

                <span class="payment-date">
                    ${escapeHtml(data.paymentDate)}
                </span>

                <input type="hidden"
                       name="Payments[${index}].PaymentDate"
                       value="${escapeHtml(data.paymentDate)}"
                       class="payment-date-input" />

            </td>

            <td>

                <span class="payment-reference">
                    ${escapeHtml(
            data.referenceNumber || '-'
        )}
                </span>

                <input type="hidden"
                       name="Payments[${index}].ReferenceNumber"
                       value="${escapeHtml(
            data.referenceNumber
        )}"
                       class="payment-reference-input" />

            </td>

            <td>

                <span class="payment-notes">
                    ${escapeHtml(
            data.notes || '-'
        )}
                </span>

                <input type="hidden"
                       name="Payments[${index}].Notes"
                       value="${escapeHtml(
            data.notes
        )}"
                       class="payment-notes-input" />

            </td>

            <td class="text-center">

                <button type="button"
                        class="btn btn-sm btn-outline-danger remove-payment"
                        title="${escapeHtml(removeText)}">

                    <i class="fa fa-trash"></i>

                </button>

            </td>

        </tr>
    `;
    }

    //function createPaymentRow(index, data) {

    //    return `
    //    <tr class="invoice-payment-row">

    //        <td>

    //            <input type="hidden"
    //                   name="Payments.Index"
    //                   value="${index}" />

    //            <input type="hidden"
    //                   name="Payments[${index}].Id"
    //                   value="0"
    //                   class="payment-id-input" />

    //            <span class="payment-type-text">
    //                ${escapeHtml(data.typeName)}
    //            </span>

    //            <input type="hidden"
    //                   name="Payments[${index}].Type"
    //                   value="${escapeHtml(data.type)}"
    //                   class="payment-type-input" />

    //        </td>

    //        <td>

    //            <span class="payment-amount">
    //                ${data.amount.toFixed(2)}
    //            </span>

    //            <input type="hidden"
    //                   name="Payments[${index}].Amount"
    //                   value="${data.amount}"
    //                   class="payment-amount-input" />

    //        </td>

    //        <td>

    //            <span class="payment-method-text">
    //                ${escapeHtml(data.paymentMethod)}
    //            </span>

    //            <input type="hidden"
    //                   name="Payments[${index}].PaymentMethod"
    //                   value="${escapeHtml(data.paymentMethod)}"
    //                   class="payment-method-input" />

    //        </td>

    //        <td>

    //            <span class="payment-date">
    //                ${escapeHtml(data.paymentDate)}
    //            </span>

    //            <input type="hidden"
    //                   name="Payments[${index}].PaymentDate"
    //                   value="${escapeHtml(data.paymentDate)}"
    //                   class="payment-date-input" />

    //        </td>

    //        <td>

    //            <span class="payment-reference">
    //                ${escapeHtml(
    //        data.referenceNumber || '-'
    //    )}
    //            </span>

    //            <input type="hidden"
    //                   name="Payments[${index}].ReferenceNumber"
    //                   value="${escapeHtml(
    //        data.referenceNumber
    //    )}"
    //                   class="payment-reference-input" />

    //        </td>

    //        <td>

    //            <span class="payment-notes">
    //                ${escapeHtml(
    //        data.notes || '-'
    //    )}
    //            </span>

    //            <input type="hidden"
    //                   name="Payments[${index}].Notes"
    //                   value="${escapeHtml(
    //        data.notes
    //    )}"
    //                   class="payment-notes-input" />

    //        </td>

    //        <td class="text-center">

    //            <button type="button"
    //                    class="btn btn-sm btn-outline-danger remove-payment"
    //                    title="${escapeHtml(removeText)}">

    //                <i class="fa fa-trash"></i>

    //            </button>

    //        </td>

    //    </tr>
    //`;
    //}

    function reindexPayments() {

        $('#payments-container')
            .children('.invoice-payment-row')
            .each(function (index) {

                const $row = $(this);

                $row.find('input[name="Payments.Index"]')
                    .val(index);

                updatePaymentInputName(
                    $row,
                    '.payment-id-input',
                    `Payments[${index}].Id`
                );

                updatePaymentInputName(
                    $row,
                    '.payment-type-input',
                    `Payments[${index}].Type`
                );

                updatePaymentInputName(
                    $row,
                    '.payment-amount-input',
                    `Payments[${index}].Amount`
                );

                updatePaymentInputName(
                    $row,
                    '.payment-method-input',
                    `Payments[${index}].PaymentMethod`
                );

                updatePaymentInputName(
                    $row,
                    '.payment-date-input',
                    `Payments[${index}].PaymentDate`
                );

                updatePaymentInputName(
                    $row,
                    '.payment-reference-input',
                    `Payments[${index}].ReferenceNumber`
                );

                updatePaymentInputName(
                    $row,
                    '.payment-notes-input',
                    `Payments[${index}].Notes`
                );
            });
    }

    function updatePaymentInputName(
        $row,
        selector,
        name
    ) {

        $row.find(selector)
            .attr('name', name);
    }

    function updatePaymentsState() {

        const $container = $('#payments-container');
        const $empty = $('#payments-empty');

        const hasPayments =
            $container.children('.invoice-payment-row').length > 0;

        $empty.toggleClass(
            'd-none',
            hasPayments
        );
    }

    function resetInvoicePaymentModal() {
        $paymentType.val('');

        $paymentMethod.val('');

        $('#invoicePaymentAmount')
            .val('0');

        $('#invoicePaymentDate')
            .val(getTodayDate());

        $('#invoicePaymentReferenceNumber')
            .val('');

        $('#invoicePaymentNotes')
            .val('');
    }

    function closeInvoicePaymentModal() {
        const modalElement =
            document.getElementById(
                'invoicePaymentModal'
            );

        const modal =
            bootstrap.Modal.getInstance(
                modalElement
            );

        if (modal) {

            modal.hide();
        }
    }

    function initializePayments() {

        reindexPayments();
    }

    // =========================================================
    // Invoice Summary
    // =========================================================

    function updateInvoiceSummary() {
        let subtotal = 0;

        $('#items-container')
            .find('.invoice-item-row')
            .each(function () {

                const total =
                    parseFloat(
                        $(this).find('.item-total-input').val()
                    ) || 0;

                subtotal += total;
            });

        const discountAmount = 0;
        const taxAmount = 0;

        const grandTotal =
            subtotal - discountAmount + taxAmount;

        let paidAmount = 0;

        $('#payments-container')
            .find('.invoice-payment-row')
            .each(function () {

                const type =
                    $(this).find('.payment-type-input').val();

                const amount =
                    parseFloat(
                        $(this).find('.payment-amount-input').val()
                    ) || 0;

                if (type === 'Receipt') {
                    paidAmount += amount;
                }

                if (type === 'Payment') {
                    paidAmount -= amount;
                }
            });

        const remainingAmount =
            grandTotal - paidAmount;

        $('#invoice-subtotal')
            .text(subtotal.toFixed(2));

        $('#invoice-discount')
            .text(discountAmount.toFixed(2));

        $('#invoice-tax')
            .text(taxAmount.toFixed(2));

        $('#invoice-grand-total')
            .text(grandTotal.toFixed(2));

        $('#invoice-paid-amount')
            .text(paidAmount.toFixed(2));

        $('#invoice-remaining-amount')
            .text(remainingAmount.toFixed(2));

    }

    // =========================================================
    // Invoice Form Submition 
    // =========================================================
    function bindInvoiceForm() {
        $('#invoice-form').on('submit', function (e) {

            if (!validateInvoiceBeforeSubmit()) {
                e.preventDefault();
            }

        });
    }

    function validateInvoiceBeforeSubmit() {
        const grandTotal =
            parseFloat($('#invoice-grand-total').text()) || 0;

        const receiptAmount =
            getTotalReceipts();

        const difference =
            Math.abs(grandTotal - receiptAmount);

        if (difference > 0.01) {

            showInvoicePaymentError(
                invoiceMessages.paymentMustEqualGrandTotal
            );

            return false;
        }

        return true;
    }

    function getTotalReceipts() {
        let total = 0;

        $('#payments-container')
            .find('.invoice-payment-row')
            .each(function () {

                const $row = $(this);

                const type =
                    $row.find('.payment-type-input').val();

                const amount =
                    parseFloat(
                        $row.find('.payment-amount-input').val()
                    ) || 0;

                if (type === 'Receipt') {
                    total += amount;
                }

            });

        return total;
    }

    // =========================================================
    // Helpers
    // =========================================================

    function escapeHtml(value) {

        return $('<div>')
            .text(value ?? '')
            .html();
    }

    function getTodayDate() {

        const today =
            new Date();

        const year =
            today.getFullYear();

        const month =
            String(
                today.getMonth() + 1
            ).padStart(2, '0');

        const day =
            String(
                today.getDate()
            ).padStart(2, '0');

        return `${year}-${month}-${day}`;
    }

});