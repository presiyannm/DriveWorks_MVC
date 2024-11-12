$(document).ready(function () {
    $('#brandSelect').change(function () {
        var brandId = $(this).val();
        console.log("Selected Brand ID: ", brandId);

        $('#modelSelect').empty().append('<option value="">Select a model</option>');

        if (brandId) {
            $.ajax({
                url: '/Home/GetModelsByBrand', // Replace 'Home' with your actual controller's name if different
                type: 'GET',
                data: { brandId: brandId },
                success: function (response) {
                    // Check if response has "$values" and use it if present
                    var models = response.$values || response;  // Use response.$values if it exists, else response

                    console.log("Fetched Models: ", models); // Verify models list

                    // Populate the models dropdown with options
                    $.each(models, function (index, model) {
                        $('#modelSelect').append('<option value="' + model.id + '">' + model.modelName + '</option>');
                    });
                },
                error: function (xhr, status, error) {
                    console.error('Error fetching models:', error);
                }
            });
        }
    });
});
