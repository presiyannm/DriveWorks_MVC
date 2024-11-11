$(document).ready(function () {
    $('#CarModel').change(function () {
        var carModelId = $(this).val(); // Get selected CarModel ID

        if (carModelId) {
            console.log("CarModel selected:", carModelId);
            $.ajax({
                url: '/Assign/GetCarPartsForModel',
                data: { carModelId: carModelId },
                type: 'GET',
                success: function (data) {
                    console.log("Data received:", data);

                    $('#CarParts').empty(); // Clear existing options

                    // Check if carParts exists and has $values (array)
                    if (data && data.carParts && data.carParts.$values && Array.isArray(data.carParts.$values) && data.carParts.$values.length > 0) {
                        // Loop through the carParts array inside $values and add them to the dropdown
                        $.each(data.carParts.$values, function (index, item) {
                            $('#CarParts').append('<option value="' + item.id + '">' + item.name + '</option>');
                        });
                    } else {
                        // No car parts found for the selected car model
                        $('#CarParts').append('<option value="">No Car Parts Available</option>');
                    }
                },
                error: function (xhr, status, error) {
                    console.error("AJAX error:", status, error);
                }
            });
        } else {
            // If no car model is selected, clear the CarParts dropdown
            $('#CarParts').empty();
            $('#CarParts').append('<option value="">-- Select Car Parts --</option>');
        }
    });
});
