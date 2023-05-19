function next()
{
    $.ajax({
        url: '/Device/VerifyCode',
        data: { code: $('#UserCode').val() },
        method: 'POST',
        success: function (result)
        {
            if (result.success)
            {
                $('#mainContent').carousel('next');
                $('#mainContent').carousel('pause');
            }
            else
            {
                $('#UserCodeVal').removeClass('d-none');
                $('#UserCodeVal').html("This code isn't valid");
            }
        }
    })


}

function prev()
{
    $('#mainContent').carousel('prev');
    $('#mainContent').carousel('pause');
}

function submit()
{
    $('#mainContent').trigger('submit');
}