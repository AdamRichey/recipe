$(document).ready(function(){  
    $( "#nabout" ).click(function() {
        $('html, body').animate({scrollTop: $('#info').offset().top -100 }, 'slow');
    });
    $( "#ntech" ).click(function() {
        $('html, body').animate({scrollTop: $('#tech').offset().top -100 }, 'slow');
      });
    $( "#nwork" ).click(function() {
        $('html, body').animate({scrollTop: $('#p1').offset().top -100 }, 'slow');
    });
    $( "#ncontact" ).click(function() {
        $('html, body').animate({scrollTop: $('#footer').offset().top -100 }, 'slow');
      }); 

      
})