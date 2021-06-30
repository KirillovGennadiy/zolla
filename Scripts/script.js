// modal
$(function () {
    $('body').on('click', '[data-type=open-modal],[data-type=open-modal] > td', (e) => {
        e.preventDefault();
        e.stopPropagation();

        let target = e.target;
        let href = $(target).attr('href');
        openModal(href);
    });

    $('.datetime').datetimepicker();

    $('#modal').on('hidden.bs.modal', (e) => {
        $('#modal-body').html(generateLoader());
    });
})

openModal = (href) => {
    $('#modal').modal('show');
    $.get(href, (data) => {
        $('#modal-body').html(data);
    })
}

ajaxSuccess = () => {
    $('#success-message').addClass('show');
    setTimeout(() => {
        $('#success-message').removeClass('show');
    }, 3000)
    $('#modal').modal('hide');
}

generateLoader = () => {
    let loader_container = document.createElement('div');
    let loader = document.createElement('div');
    let loader_inner = document.createElement('span');

    loader_container.classList = 'd-flex justify-content-center m-5';

    loader.classList = 'spinner-border';
    loader.role = 'status';

    loader_inner.classList = 'sr-only';
    loader_inner.textContent = 'Loading...';

    loader.appendChild(loader_inner);
    loader_container.appendChild(loader);

    return loader_container;
}
