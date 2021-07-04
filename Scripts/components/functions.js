// Update block with data that returned from ajax get request
const updateBlock = (selector) => {
    let updateUrl = $(selector).data('update-url');
    $.get(updateUrl, (data) => {
        $(selector).html(data);
    });
}

// Function to call on success ajax 
const ajaxSuccess = (targetUpdateSelector, data) => {
    if (data.success) {
        updateBlock(targetUpdateSelector);
        $('#modal').modal('hide');
        showSuccessMessage();
    } else {
        populateFormErrors(data.errors);
    }

}

// Show and hide success message
const showSuccessMessage = () => {
    $('#success-message').addClass('show');
    setTimeout(() => {
        $('#success-message').removeClass('show');
    }, 3000)
}

// Generate bootstrap loader element
const generateLoader = () => {
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