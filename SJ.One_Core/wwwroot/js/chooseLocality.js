$(document).ready(function () {

    $(function () {
        $('.selectpicker').selectpicker();
    });

    let form = $('#AjaxAntiForgeryForm');
    let token = $('input[name="__RequestVerificationToken"]', form).val();

    function refreshListLocality(regionId) {
        $.ajax({
            type: 'GET',
            url: '/Locality/GetLocalitiesDropDownList/' + regionId,
            success: function (data) {
                $('#newLocalityForm').hide();
                $('#localities').html(data);
                $('#localities').show();
            }
        });
    }

    $('#regionList').change(function () {
        let regionId = $(this).val();
        refreshListLocality(regionId);
    });

    $(document).on('click', '#newLocality', function () {
        $('#newLocalityForm').show();
        $('#localities').hide();
        $('#submit').prop('disabled', true);
        $('#locality').focus();
        $('#locality').keyup(function () {
            if ($(this).val().length > 0) {
                $('#addLocality').prop('disabled', false);
            }
            else {
                $('#addLocality').prop('disabled', true);
            }
        });
    });

    $('#addLocality').click(function () {
        $('#newLocalityForm').hide();
        $('#localities').show();
        $('#submit').prop('disabled', false);
        let locality = $('#locality').val();
        let regionId = $('#regionList').val();

        $.ajax({
            type: 'POST',
            url: '/Locality/AddNewLocality/',
            dataType: 'json',
            data: { __RequestVerificationToken: token, RegionId: regionId, Name: locality },
            success: function (response) {
                alert(response.responseText);
                $('#locality').val('');
                refreshListLocality(regionId);
            },
            error: function (response) {
                alert(response.responseText);
            }
        });
    });

    $('#toListLocality').click(function () {
        $('#newLocalityForm').hide();
        $('#locality').val('');
        $('#addLocality').prop('disabled', true);
        $('#localities').show();
        $('#submit').prop('disabled', false);
    });
});