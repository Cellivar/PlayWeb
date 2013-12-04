$(document).ready(function() {
	$(".logout-button").click(function () {
		$.ajax(
			{
				url: '/api/account/logout',
				cache: false,
				type: 'GET',
				success: function() {
					window.location.href = '/';
				}
			});
	})
})
