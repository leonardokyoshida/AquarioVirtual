;(function () {
	
	'use strict';



	// iPad and iPod detection	
	var isiPad = function(){
		return (navigator.platform.indexOf("iPad") != -1);
	};

	var isiPhone = function(){
	    return (
			(navigator.platform.indexOf("<i></i>Phone") != -1) || 
			(navigator.platform.indexOf("iPod") != -1)
	    );
	};

	
	

	// Click outside of offcanvass
	var mobileMenuOutsideClick = function() {

		$(document).click(function (e) {
	    var container = $("#fh5co-offcanvas, .js-fh5co-close-offcanvas");
	    if (!container.is(e.target) && container.has(e.target).length === 0) {

	        //verifica se j� existe a classe animated e fadeinLeft na tag com id #fh5co-offcanvas --L.K
            //Ou seja, verifica se o menu est� aberto ou n�o
	    	if ( $('#fh5co-offcanvas').hasClass('animated fadeInLeft') ) {
                //Se existir, ele adiciona a classe fadeOutLeft para fechar o menu
    			$('#fh5co-offcanvas').addClass('animated fadeOutLeft');
    			setTimeout(function () {
                    //seta o display para none para fechar o menu
					$('#fh5co-offcanvas').css('display', 'none');	
					$('#fh5co-offcanvas').removeClass('animated fadeOutLeft fadeInLeft');
				}, 1000);
				$('.js-fh5co-nav-toggle').removeClass('active');
				
	    	}
	    
	    	
	    }
		});

        //Click do bot�o close do menu
		$('body').on('click', '.js-fh5co-close-offcanvas', function(event){
		

	  		$('#fh5co-offcanvas').addClass('animated fadeOutLeft');
			setTimeout(function(){
				$('#fh5co-offcanvas').css('display', 'none');	
				$('#fh5co-offcanvas').removeClass('animated fadeOutLeft fadeInLeft');
			}, 1000);
			$('.js-fh5co-nav-toggle').removeClass('active');

            //Metodo impede que a pagina seja recarregada com a acao do click
	    	event.preventDefault();

		});

	};

	

	

	// Burger Menu
	var burgerMenu = function() {
        //tratando o click do botao Menu 
		$('body').on('click', '.js-fh5co-nav-toggle', function(event){

			var $this = $(this);
            //adicionando no menu display block para exibir o menu
			$('#fh5co-offcanvas').css('display', 'block');
			setTimeout(function(){
				$('#fh5co-offcanvas').addClass('animated fadeInLeft');
			}, 100);
			
		    // $('body').toggleClass('fh5co-overflow offcanvas-visible');

		    //Adicionando class active para identificar que o menu est� sendo exibido
			$this.toggleClass('active');
			event.preventDefault();

		});

	};

	var scrolledWindow = function() {

		$(window).scroll(function(){

			var header = $('#fh5co-header'),
				scrlTop = $(this).scrollTop();


		   $('#fh5co-home .flexslider .fh5co-overlay').css({
				'opacity' : (.5)+(scrlTop/2000)
		   });

		   if ( $('body').hasClass('offcanvas-visible') ) {
		   	$('body').removeClass('offcanvas-visible');
		   	$('.js-fh5co-nav-toggle').removeClass('active');
		   }
		 
		});

		$(window).resize(function() {
			if ( $('body').hasClass('offcanvas-visible') ) {
		   	$('body').removeClass('offcanvas-visible');
		   	$('.js-fh5co-nav-toggle').removeClass('active');
		   }
		});
		
	};


	

	// Page Nav
	var clickMenu = function() {
		var topVal = ( $(window).width() < 769 ) ? 0 : 58;

		$(window).resize(function(){
			topVal = ( $(window).width() < 769 ) ? 0 : 58;		
		});

		if ( $(this).attr('href') != "#") {
			$('#fh5co-main-nav a:not([class="external"]), #fh5co-offcanvas a:not([class="external"])').click(function(event){
				var section = $(this).data('nav-section');


				if ( $('div[data-section="' + section + '"]').length ) {

					$('html, body').animate({
			        	scrollTop: $('div[data-section="' + section + '"]').offset().top - topVal
			    	}, 500);	
			    	
			   }
			   event.preventDefault();

			});
		}

		


	};


	var contentWayPoint = function() {
		var i = 0;
		$('.animate-box').waypoint( function( direction ) {

			if( direction === 'down' && !$(this.element).hasClass('animated') ) {
				
				i++;

				$(this.element).addClass('item-animate');
				setTimeout(function(){
					
					$('body .animate-box.item-animate').each(function(k){
						var el = $(this);
						setTimeout( function () {
							el.addClass('fadeInUp animated');
							el.removeClass('item-animate');
						},  k * 200, 'easeInOutExpo' );
					});
					
				}, 100);
				
			}

		} , { offset: '85%' } );


	};


	// Document on load.
	$(function(){

		mobileMenuOutsideClick();
		burgerMenu();
		scrolledWindow();
		
		// Animations
		contentWayPoint();
		
		

	});


	$('#login-form-link').click(function (e) {
	    $("#login-nav").delay(100).fadeIn(100);
	    $("#register-form").fadeOut(100);
	    $('#register-form-link').removeClass('active');
	    $(this).addClass('active');
	    e.preventDefault();
	});

	$('#register-form-link').click(function (e) {
	    $("#register-form").delay(100).fadeIn(100);
	    $("#login-nav").fadeOut(100);
	    $('#login-form-link').removeClass('active');
	    $(this).addClass('active');
	    e.preventDefault();
	});

}());