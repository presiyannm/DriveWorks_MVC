$(document).ready(function () {
    // Handle the brand select change event
    $('#brandSelect').change(function () {
        var brandId = $(this).val();

        // Clear the model select dropdown and add a default option
        $('#modelSelect').empty().append('<option value="" selected disabled>Select a model</option>');

        if (brandId) {
            // Make AJAX request to fetch models based on the selected brand
            $.ajax({
                url: '/Home/GetModelsByBrand',
                type: 'GET',
                data: { brandId: brandId },
                success: function (response) {
                    // Use response.$values if present, otherwise use the response itself
                    var models = response.$values || response;

                    // Populate the model select dropdown with the fetched models
                    $.each(models, function (index, model) {
                        var modelId = model.id || model.$id; // Use model.id or model.$id if available
                        $('#modelSelect').append('<option value="' + modelId + '">' + model.modelName + '</option>');
                    });
                },
                error: function () {
                    console.error('Error fetching models');
                }
            });
        }
    });

    // Handle the model select change event
    $('#modelSelect').change(function () {
        var modelId = $(this).val();

        if (modelId) {
            // Trigger any additional function on model change, e.g., get car parts
            getCarPartsByModel(modelId);
        }
    });
});

// Example function to get car parts by model
function getCarPartsByModel(modelId) {
    $.ajax({
        url: '/Home/GetCarPartsByModel', // Adjust this URL to your controller's action
        type: 'GET',
        data: { modelId: modelId },
        success: function (response) {
            // Handle the car parts data (e.g., update the page with car parts)
        },
        error: function () {
            console.error('Error fetching car parts');
        }
    });
}
