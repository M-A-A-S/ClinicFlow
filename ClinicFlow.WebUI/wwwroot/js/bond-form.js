/**
 * Handles Bond Modal interactions:
 * 1. Auto-selects Bond Type based on Category.
 * 2. Filters & enables/disables Party list based on Party Type.
 */



var BondModal = (function () {
    let $categorySelect;
    let $typeSelect;
    let $partyTypeSelect;
    let $partyEntitySelect;
    let originalPartyOptions = [];

    

    function init() {
        $categorySelect = $('#categoryId');
        $typeSelect = $('#typeId');
        $partyTypeSelect = $('#partyTypeSelect');
        $partyEntitySelect = $('#partyEntitySelect');


        // Store original party entity options for filtering
        originalPartyOptions = $partyEntitySelect.find('option').clone();

        bindEvents();

        // Initial setup for Edit mode or re-renders
        filterPartyEntities();
    }

    function bindEvents() {
        // 1. Auto-select Bond Type when Category changes
        $categorySelect.on('change', function () {
            const selectedOption = $(this).find('option:selected');
            const categoryType = selectedOption.data('type');

            //console.log('selectedOption -> ', selectedOption)
            //console.log('categoryType -> ', categoryType)

            if (categoryType !== undefined && categoryType !== null && categoryType !== '') {
                $typeSelect.val(categoryType).trigger('change');
            } else {
                $typeSelect.val('').trigger('change');
            }
        });

        // 2. Filter Party dropdown when Party Type changes
        $partyTypeSelect.on('change', filterPartyEntities);
    }

    function filterPartyEntities() {
        const selectedVal = $partyTypeSelect.val();
        const selectedOption = $partyTypeSelect.find('option:selected');
        const enumKey = selectedOption.data('enum-name'); // Returns "Patient" or "Doctor"

        // Disabled by default if no Party Type selected
        if (!selectedVal || !enumKey) {
            $partyEntitySelect.val('').prop('disabled', true).trigger('change');
            return;
        }

        // Enable dropdown
        $partyEntitySelect.prop('disabled', false);

        // Preserve current selected value before clearing options
        const currentSelectedId = $partyEntitySelect.val();

        // Rebuild options matching selected party type
        $partyEntitySelect.empty();

        // Add default placeholder option
        $partyEntitySelect.append(originalPartyOptions.first().clone());

        // Append matching elements
        originalPartyOptions.each(function () {
            const optionPartyType = $(this).data('party-type');
            if (optionPartyType && optionPartyType.toLowerCase() === enumKey.toLowerCase()) {
                $partyEntitySelect.append($(this).clone());
            }
        });

        // Restore selected value if valid, or clear
        if (currentSelectedId && $partyEntitySelect.find(`option[value="${currentSelectedId}"]`).length > 0) {
            $partyEntitySelect.val(currentSelectedId);
        } else {
            $partyEntitySelect.val('');
        }

        $partyEntitySelect.trigger('change');
    }

    return {
        init: init
    };
})();

// Initialize when DOM is ready or inside Bootstrap Modal 'shown.bs.modal' event
$(document).ready(function () {
    BondModal.init();
});