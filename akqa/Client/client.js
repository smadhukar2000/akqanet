$(document).ready(function () {

	// TODO: change port number, if required
	var port = 7633;
	function apiResult(response)
	{
		console.log(response);
		$('#txtResult').html(response.AmountInWords);		
	}

	// validate inputs
	$(document).on('click', '#btnConvertNow', function () {

		var name = $('#txtName').val().trim();
		var amount = parseFloat($('#txtAmount').val().trim());
		if (name.length == 0 )
		{
			alert("Name can't be empty");
			$('#txtName').focus();
			return;
		}

		if (isNaN(amount)) {
			alert("Invalid amount");
			$('#txtAmount').focus();
			return;
		}
		
		var url = akqaSprintf("http://localhost:%s/api/akqa/convertnumbers/%s/%s/", port, name, amount);	
		$.ajax({
			type: 'get',
			url: url,
			success: apiResult,
			error: apiResult,
		});

	});

});

function akqaSprintf() {
	var args = arguments,
		string = args[0],
		i = 1;
	return string.replace(/%((%)|s|d)/g, function (m) {
		// m is the matched format, e.g. %s, %d
		var val = null;
		if (m[2]) {
			val = m[2];
		} else {
			val = args[i];
			// A switch statement so that the formatter can be extended. Default is %s
			switch (m) {
				case '%d':
					val = parseFloat(val);
					if (isNaN(val)) {
						val = 0;
					}
					break;
			}
			i++;
		}
		return val;
	});
}