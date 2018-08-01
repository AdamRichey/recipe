$(document).ready(function(){  
    $('#contactform').submit(function(event) {
    var data = JSON.stringify({
        'name'     : $('input[name=name]').val(),
        'company'  : $('input[name=company]').val(),
        'email'    : $('input[name=email]').val(),
        'phone'    : $('input[name=phone]').val(),
        });
    $.ajax({
        type    : 'POST',
        url     : '', 
        data    : data, 
        contentType: 'application/json', 
        dataType: 'object',
    })
    console.log(data)
    
    event.preventDefault();
    $('#contactform').trigger("reset")
    $('#success').append('<div class="alert alert-success">Thank You, Message Sent.</div>');
    $.post( "", function(data) {
        console.log(data)
      });
    })
})