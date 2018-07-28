function clearInput(element) {
	$(element).val("");
}

function runDeposit(amount) {
	$.ajax({
    type: "POST",
    data: { amount: amount },
    url: '/account/deposit/' + amount,
    success: function(result) {
			console.log(result);
			// hide balance, show load gif
			// show balance
      updateBalance(result.amount);
    },
    error: function(err) {
      console.log("Error: " + JSON.stringify(err));
    }
  });
}

function updateBalance(amount) {
	amount = roundTwoDecimals(amount);
	$("#balance-result").text(amount);
}

function roundTwoDecimals(number) {
	return Math.round(number * 100) / 100;
}

$(document).ready(function() {
  $("#make-deposit").click(function() {
		console.log("clicked deposit!");
		var amount = parseFloat($("#deposit-amount").val());
		clearInput("#deposit-amount");
		runDeposit(amount);
	});
});
