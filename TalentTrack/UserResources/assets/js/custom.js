$(window).on("load", function() {
    "use strict";



    
    $('.jbm-spinner').fadeOut(600);

    	// Popup Functions

	$(".apply-btn").on("click", function(){
    	$(".apply-job-popup").addClass("active");
   		return false;
	}); 
	$('.close-btn, .popup-overlay').on("click",function(){
	    $(".apply-job-popup").removeClass("active");
	});
	$(".apply-btn, .apply-job-popup").on("click", function(e){
		e.stopPropagation();
	});

	$(".login-pop").on("click", function(){
    $(".jbm-login-popup").addClass("active");
    return false;
	}); 
	$(".close-btn,.popup-overlay").on("click", function(){
		$(".jbm-login-popup").removeClass("active");
	});
	$('.login-pop, .jbm-login-popup').on("click",function(e){
	    e.stopPropagation();
	});

	$(".register-pop").on("click", function(){
    $(".jbm-can-register-popup").addClass("active");
	return false;
	}); 
	$('.close-btn, .popup-overlay').on("click",function(){
	    $(".jbm-can-register-popup").removeClass("active");
	});
	$(".register-pop, .jbm-can-register-popup").on("click", function(e) {
		e.stopPropagation();
	});

	$('.form-control').on('blur',function() {
	    if( $(this).val().length === 0 ) {
	        $(this).closest('.form-group').removeClass('field-active');
	    }else{
	        $(this).closest('.form-group').addClass('field-active');
	    }
	});
    // Tabs functionality in tabs

	$('.jbm-form.regis ul li').on("click", function(){
	    var tab_id = $(this).attr('data-tab');
	    $('.jbm-form ul li').removeClass('selected');
	    $('.jbm-field').removeClass('current');
	    $(this).addClass('selected');
	    $("#"+tab_id).addClass('current');
	});
	// Login form active 
	$(".jbm-form ul li").on("click", function(){
		$(this).addClass("selected").siblings().removeClass("selected");
	});

	 $('.slider-for').slick({
	  slidesToShow: 1,
	  slidesToScroll: 1,
	  arrows: false,
	  fade: true,
	  asNavFor: '.slider-nav'
	});
	$('.slider-nav').slick({
	  slidesToShow: 5,
	  slidesToScroll: 1,
	  asNavFor: '.slider-for',
	  dots: false,
	  vertical: true,
	  verticalSwiping: true,
	  centerMode: false,
	  focusOnSelect: true
	});

	$('.jbm-partner-list').slick({
		slidesToShow: 5,
		slidesToScroll: 1,
		arrows: false,
		responsive: [
		    {
		      breakpoint: 780,
		      settings: {
				slidesToShow: 3,
				slidesToScroll: 1,
		      }
		    },
		    {
		      breakpoint: 480,
		      settings: {
				slidesToShow: 1,
				slidesToScroll: 1,
		      }
		    }
		],
	});


	$('.jbm-searchform').on('click', function(){
		if($(this).hasClass('searchform-active')){
			$(this).removeClass('searchform-active');
			$(this).find('i').addClass('fa-search');
			$(this).find('i').removeClass('fa-times');
			$('.search-bar').slideUp();
		}else{
			$(this).addClass('searchform-active');
			$(this).find('i').removeClass('fa-search');
			$(this).find('i').addClass('fa-times');
			$('.search-bar').slideDown();
		}
	});
	$('.jbm-menu-icon,.jbm-menu-icon,.jbm-overlay').on('click', function(){
		if($('body').hasClass('mobm-active')){
			$('body').removeClass('mobm-active');
		}else{
			$('body').addClass('mobm-active');
		}
	});
	$('.jbm-mobile-menu-wrap > ul > li').on('click', function(){
		if($(this).hasClass('mob-menu-active')){

			$(this).find('.mobile-submenu').slideUp();
			$(this).removeClass('mob-menu-active');

		}else{

			$(this).addClass('mob-menu-active');
			$(this).find('.mobile-submenu').slideDown();

		}
	});
	var windows = screen_height();
	var logo = $('.jbm-mobile-logo-wrap').height();
	var search = $('.jbm-mobile-search-wrap').height();
	var bottom = $('.jbm-mobile-bottom-wrap').height();
	var height1 = logo + search + bottom;
	var menu_height = (windows - height1) - 100;
	console.log(menu_height);
	$('.jbm-mobile-menu-wrap').css("max-height",menu_height);

	$('.jbm-accordion-more.info-active').slideDown();
	$('.expand-candi-info').on('click', function(e){
		e.preventDefault();
		if($(this).closest('.jbm-accordion').find('.jbm-accordion-more').hasClass('info-active')){
			$(this).closest('.jbm-accordion').find('.jbm-accordion-more').removeClass('info-active');
			$(this).closest('.jbm-accordion').find('.expand-candi-info .fa').removeClass('fa-minus');
			$(this).closest('.jbm-accordion').find('.expand-candi-info .fa').addClass('fa-plus');
			$(this).closest('.jbm-accordion').find('.expand-candi-info').removeClass('info-active');
			$(this).closest('.jbm-accordion').find('.jbm-accordion-more').slideUp();
		}else{
			$(this).closest('.jbm-accordion').find('.jbm-accordion-more').addClass('info-active');
			$(this).closest('.jbm-accordion').find('.expand-candi-info .fa').removeClass('fa-plus');
			$(this).closest('.jbm-accordion').find('.expand-candi-info .fa').addClass('fa-minus');
			$(this).closest('.jbm-accordion').find('.jbm-accordion-more').slideDown();
		}
	});
	$('.jbm-select').select2();
	$(".jbm-select-hide-search").select2({
	  minimumResultsForSearch: Infinity
	});
	$(".back-top-button,.back-top-link").on('click',function() {
	  $("html, body").animate({ scrollTop: 0 }, "slow");
	  return false;
	});


});
function screen_height() {
    var x = screen.height;
    return  x;
}

