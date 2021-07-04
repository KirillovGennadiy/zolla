// modal
$(function () {
    // Open modal window when click on element with data type "open-modal"
    $('body').on('click', '[data-type=open-modal]', (e) => {
        e.preventDefault(); // Cancel default event

        let target = e.target; // Get the clcked element
        let updateAfterModalHide = target.dataset.targetUpdate;
        let href = $(target).attr('href');
        openModal(href, updateAfterModalHide); // call openModal function
    });

    // when modal hide, replace body by loader
    $('#modal').on('hidden.bs.modal', (e) => {
        $('#modal-body').html(generateLoader());
    });
})

const openModal = (href) => {
    // open modal
    $('#modal').modal('show');
    $.get(href, (data) => {
        // fill modal body by content
        $('#modal-body').html(data);
        // init datetimepicker if form contains datetime fields
        initDatePicker('#modal-body', '.datetime');
        initMaskedInput('#modal-body', '.format');
    })
}

