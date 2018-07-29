function clearInput(element) {
  $(element).val("");
}

function runDeposit(amount) {
  if (checkForNaN(amount)) return displayErrorAlert();

  $.ajax({
    type: "POST",
    data: { amount: amount },
    url: '/account/deposit/' + amount,
    success: function(result) {
      var msg = "You deposited $" + roundTwoDecimals(amount).toFixed(2) + " into your account."
      displayAccountAlert(msg);
      displayUpdatedBalance(result.balance);
    },
    error: function(err) {
      displayErrorAlert();
      console.log("Error: " + JSON.stringify(err));
    }
  });
}

function runWithdrawal(amount) {
  if (notValidInput(amount)) return displayErrorAlert();

  $.ajax({
    type: "POST",
    data: { amount: amount },
    url: '/account/withdraw/' + amount,
    success: function(result) {
      var msg = "You widthrew $" + roundTwoDecimals(amount).toFixed(2) + " from your account."
      displayAccountAlert(msg);
      displayUpdatedBalance(result.balance);
    },
    error: function(err) {
      displayErrorAlert();
      console.log("Error: " + JSON.stringify(err));
    }
  });
}

function checkForNaN(amount) {
  var amount = parseFloat(amount);
  return isNaN(amount);
}

function notValidInput(amount) {
  return (checkForNaN(amount) || balanceWillBeNegative(amount));
}

function balanceWillBeNegative(amount) {
  var input = parseInt(amount);
  var balance = parseInt($("#balance-result").text());
  var result = balance - input;
  return (result < 0);
}

function displayErrorAlert() {
  $(".alert-errors").fadeIn(1200).delay(3000).fadeOut(1200);
}

function displayAccountAlert(msg) {
  $("#alert-update-balance-msg").text(msg);
  $(".alert-update-balance").fadeIn(1200).delay(3000).fadeOut(1200);
}

function displayUpdatedBalance(balance) {
  roundedBalance = roundTwoDecimals(balance).toFixed(2);
  $("#balance-result").text("$" + roundedBalance);
}

function roundTwoDecimals(number) {
  return Math.round(number * 100) / 100;
}

$(document).ready(function() {
  $("#make-deposit").click(function() {
    var amount = $("#deposit-amount").val();
    clearInput("#deposit-amount");
    runDeposit(amount);
  });

  $("#make-withdrawal").click(function() {
    var amount = $("#withdraw-amount").val();
    clearInput("#withdraw-amount");
    runWithdrawal(amount);
  });
});
