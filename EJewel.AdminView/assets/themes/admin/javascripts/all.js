var Nav = function () {
	
	return { init: init, open: open };
	
	function init () {
		$('li.nav').each (function () {		
			var li, a, dropdown;
			li = $(this);
			a = li.find ('a').eq (0);						
			dropdown = li.find ('.subNav');
			
			if (dropdown.length > 0) {
				a.append ('<span class="dropdownArrow"></span>');
				li.addClass ('dropdown');
				a.bind ('click',navClick);
			}
		});
		
		var active = $('li.nav.active');
		
		if (active.is ('.dropdown')) {
			var id = active.attr ('id');
			
			active.addClass ('opened');
			active.find ('.subNav').show ();
		}
	}
	
	function open (id) {
		var el = $('#' + id)
		,	sub = el.find ('.subNav');
		
		el.addClass ('opened');
		sub.slideToggle ();
	}
	
	function navClick (e) {
		e.preventDefault ();
		
		var li = $(this).parents ('li');		
		
		if (li.is ('.opened')) { 
			closeAll ();			
		} else { 
			closeAll ();
			li.addClass ('opened').find ('.subNav').slideDown ();			
		}
		
		//closeAll ();
		//$(this).parents ('li.nav').addClass ('opened').find ('.subNav').slideToggle ();
	}
	
	function closeAll () {
		var subnav = $('.subNav');
		
		subnav.slideUp ().parents ('li').removeClass ('opened');
	}
}();

(function($) {

$.modal = function (config) {
	
	var defaults, options, container, header, close, content, title, overlay;
	
	defaults = {
		 title: ''
		, html: ''
		, ajax: ''
		, width: null
		, overlay: true
		, overlayClose: false
		, escClose: true
	};
	
	options = $.extend (defaults, config);
	
	container = $('<div>', { id: 'modal' });
	header = $('<div>',  { id: 'modalHeader' });
	content = $('<div>', { id: 'modalContent' });
	overlay = $('<div>', { id: 'overlay' });
	title = $('<h2>', { text: options.title });
	close = $('<a>', { 'class': 'close', href: 'javascript:;', html: '&times' });

	container.appendTo ('body');
	header.appendTo (container);
	content.appendTo (container);
	if (options.overlay) {
		overlay.appendTo ('body');
	}
	title.prependTo (header);
	close.appendTo (header);
	
	if (options.ajax == '' && options.html == '') {
		title.text ('No Content');
	}
	
	if (options.ajax !== '') {
		content.html ('<div id="modalLoader"><img src="./img/ajax-loader.gif" /></div>');
		$.modal.reposition ();
		$.get (options.ajax, function (response) {
			content.html (response);
			$.modal.reposition ();
		});
	}
	
	if (options.html !== '') {
		content.html (options.html);
	}
	
	close.bind ('click', function (e) { 
		e.preventDefault (); 
		$.modal.close (); 		
	});
	
	if (options.overlayClose) {
		overlay.bind ('click', function (e) { $.modal.close (); });
	}
	
	if (options.escClose) {
		$(document).bind ('keyup.modal', function (e) {
			var key = e.which || e.keyCode;
			
			if (key == 27) {
				$.modal.close ();
			}			
		});
	}
	
	$.modal.reposition ();
}

$.modal.reposition = function () {
	var width = $('#modal').outerWidth ();		
	var centerOffset = width / 2;	
	$('#modal').css ({ 'left': '50%', 'top': $(window).scrollTop () + 75, 'margin-left': '-' + centerOffset + 'px' });
};

$.modal.close = function () {
	$('#modal').remove ();
	$('#overlay').remove ();
	$(document).unbind ('keyup.modal');
}

function getPageScroll() {
	var xScroll, yScroll;
	
	if (self.pageYOffset) {
		yScroll = self.pageYOffset;
		xScroll = self.pageXOffset;
	} else if (document.documentElement && document.documentElement.scrollTop) {	 // Explorer 6 Strict
		yScroll = document.documentElement.scrollTop;
		xScroll = document.documentElement.scrollLeft;
	} else if (document.body) {// all other Explorers
		yScroll = document.body.scrollTop;
		xScroll = document.body.scrollLeft;
	}
	
	return new Array(xScroll,yScroll);
}

})(jQuery);

(function($) {

$.alert = function (config) {
	
	var defaults, options, container, content, actions, close, submit, cancel, title, overlay;
	
	defaults = {
		type: 'default'
		, title: ''
		, text: ''
		, confirmText: 'Confirm'
		, cancelText: 'Cancel'
		, callback: function () {}
		, overlayClose: false
		, escClose: true
	};
	
	options = $.extend (defaults, config);
	
	container = $('<div>', { id: 'alert' });
	content = $('<div>', { id: 'alertContent' });
	close = $('<a>', { 'class': 'close', href: 'javascript:;', html: '&times' });
	actions = $('<div>', { id: 'alertActions' });
	overlay = $('<div>', { id: 'overlay' });
	title = $('<h2>', { text: options.title });
	
	submit = $('<button>', { 'class': 'btn btn-small btn-primary', text: options.confirmText });
	cancel = $('<button>', { 'class': 'btn btn-small btn-quaternary', text: options.cancelText });

	container.appendTo ('body');
	content.appendTo (container);
	close.appendTo (container);
	overlay.appendTo ('body');
	title.prependTo (content);
	
	content.append (options.text);
	
	actions.appendTo (content);
	
	if (options.type === 'confirm') {
		submit.appendTo (actions);
		cancel.appendTo (actions);
	} else {
		submit.appendTo (actions);
		submit.text ('Ok');
	}	
	
	submit.bind ('click', function (e) { 
		e.preventDefault (); 
		
		if (typeof options.callback === 'function') {
			options.callback.apply ();
		}
		
		$.alert.close (); 
	});
	
	submit.focus ();
	
	cancel.bind ('click', function (e) { 
		e.preventDefault (); 
		$.alert.close (); 		
	});
	
	close.bind ('click', function (e) {
		e.preventDefault ();
		$.alert.close ();
	});
	
	if (options.overlayClose) {
		overlay.bind ('click', function (e) { $.alert.close (); });
	}
	
	if (options.escClose) {
		$(document).bind ('keyup.alert', function (e) {
			var key = e.which || e.keyCode;
			
			if (key == 27) {
				$.alert.close ();
			}			
		});
	}
	
	
}

$.alert.close = function () {
	$('#alert').remove ();
	$('#overlay').remove ();
	$(document).unbind ('keyup.alert');
}
})(jQuery);

$(function () {
	Nav.init ();
});
function notifyClose (e) {
	e.preventDefault ();
	
	$(this).parents ('.notify').slideUp ('medium', function () { $(this).remove (); });
}
function toggleNav (e) {
	e.preventDefault ();
	
	$('#sidebar').toggleClass ('revealShow');
}

