$(document).ready(function () {

    $('#submit').prop('disabled', true);

    $(function () {
        $('.selectpicker').selectpicker();
    });

    let form = $('#AjaxAntiForgeryForm');
    let token = $('input[name="__RequestVerificationToken"]', form).val();

    function refreshClubListLocality(clubRegionId) {
        $.ajax({
            type: 'GET',
            url: '/Locality/GetLocalitiesDropDownList/' + clubRegionId,
            success: function (data) {
                $('#newClubLocalityForm').hide();
                $('#clubLocalities').html(data);
                $('#clubLocalities').show();
            }
        });
    }

    function refreshListClubs(localityClubId) {
        $.ajax({
            type: 'GET',
            url: '/SportClub/GetSportClubsDropDownList/' + localityClubId,
            success: function (data) {
                $('#newClubForm').hide();
                $('#clubs').html(data);
                $('#clubs').show();
            }
        });
    }

    $(document).on('change', '#clubRegionList', function () {
        let clubRegionId = $(this).val();
        let clubLocalityId = 0;
        refreshClubListLocality(clubRegionId);
        refreshListClubs(clubRegionId, clubLocalityId);
    });

    $(document).on('change', '#clubLocalityList', function () {
        let localityId = $(this).val();
        if (localityId === 0) {
            $('#clubs').hide();
        }
        else {
            refreshListClubs(localityId);
        }
    });

    $(document).on('click', '#newClubLocality, #newLocality', function () {
        $('#newClubLocalityForm').show();
        $('#clubLocalities').hide();
        $('#clubLocality').focus();
        $('#clubLocality').keyup(function () {
            if ($(this).val().length > 0) {

                $('#addClubLocality').prop('disabled', false);
            }
            else {
                $('#addClubLocality').prop('disabled', true);
            }
        });
    });

    $('#toListClubLocality').click(function () {
        $('#newClubLocalityForm').hide();
        $('#clubLocality').val('');
        $('#addClubLocality').prop('disabled', true);
        $('#clubLocalities').show();
    });

    $(document).on('change', '#clubList', function () {
        let sportClub = $(this).val();
        if (sportClub > 0) {
            $('#submit').prop('disabled', false);
        }
        else {
            $('#submit').prop('disabled', true);
        }
    });

    $(document).on('click', '#newClub', function () {
        $('#newClubForm').show();
        $('#clubs').hide();
        $('#club').focus();
        $('#club').keyup(function () {
            if ($(this).val() != '') {
                $('#addClub').prop('disabled', false);
            }
            else {
                $('#addClub').prop('disabled', true);
            }
        });
    });

    $('#toListClub').click(function () {
        $('#newClubForm').hide();
        $('#club').val('');
        $('#addClub').prop('disabled', true);
        $('#clubs').show();
    });

    $(document).on('click', '#addClubLocality', function () {
        $('#newClubLocalityForm').hide();
        $('#clubLocalities').show();
        let clubLocality = $('#clubLocality').val();
        let clubRegionId = $('#clubRegionList').val();

        $.ajax({
            type: 'POST',
            url: '/Locality/AddNewLocality/',
            dataType: 'json',
            data: { __RequestVerificationToken: token, RegionId: clubRegionId, Name: clubLocality },
            success: function (response) {
                alert(response.responseText);
                $('#clubLocality').val('');
                refreshClubListLocality(clubRegionId);
            },
            error: function (response) {
                alert(response.responseText);
            }
        });
    });

    $(document).on('click', '#addClub', function () {
        let localityClubId = $('#clubLocalityList').val();
        let club = $('#club').val();
        $.ajax({
            type: 'POST',
            url: '/SportClub/AddNewSportClub',
            dataType: 'json',
            data: { __RequestVerificationToken: token, LocalityId: localityClubId, Name: club },
            success: function (response) {
                alert(response.responseText);
                refreshListClubs(localityClubId);
                $('#newClubForm').hide();
                $('#clubs').show();
                $('#club').val('');
            },
            error: function (response) {
                alert(response.responseText);
            }
        });
    });
});