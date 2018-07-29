function clearInput(element) {
  $(element).val("");
}

function runDeposit(inputAmount) {
  if (checkForNaN(inputAmount)) return displayErrors();

  $.ajax({
    type: "POST",
    data: { amount: inputAmount },
    url: '/account/deposit/' + inputAmount,
    success: function(result) {
      displayDepositMsg();
      displayUpdatedBalance(inputAmount, result);
    },
    error: function(err) {
      console.log("Error: " + JSON.stringify(err));
    }
  });
}

function runWithdrawal(inputAmount) {
  if (notValidInput(inputAmount)) return displayErrors();

  $.ajax({
    type: "POST",
    data: { amount: inputAmount },
    url: '/account/withdraw/' + inputAmount,
    success: function(result) {
      displayWithdrawMsg();
      displayUpdatedBalance(inputAmount, result);
    },
    error: function(err) {
      console.log("Error: " + JSON.stringify(err));
    }
  });
}

function checkForNaN(inputAmount) {
  var inputAmount = parseFloat(inputAmount);
  return isNaN(inputAmount);
}

function notValidInput(inputAmount) {
  return (checkForNaN(inputAmount) || balanceWillBeNegative(inputAmount));
}

function balanceWillBeNegative(inputAmount) {
  var input = parseInt(inputAmount);
  var balance = parseInt($("#balance-result").text());
  var result = balance - input;
  return (result < 0);
}

function displayErrors() {
  $(".alert-errors").fadeIn(1200).delay(3000).fadeOut(1200);
}

function displayDepositMsg() {
  resetMsgDisplay();
  $("#alert-deposit-msg").show();
}

function displayWithdrawMsg() {
  resetMsgDisplay();
  $("#alert-withdraw-msg").show();
}

function resetMsgDisplay() {
  $("#alert-withdraw-msg").hide();
  $("#alert-deposit-msg").hide();
}

function displayUpdatedBalance(inputAmount, balanceObject) {
  roundedInput = roundTwoDecimals(inputAmount);
  roundedBalance = roundTwoDecimals(balanceObject.balance);
  displayAlert(roundedInput);
  updateBalance(roundedBalance);
}

function roundTwoDecimals(number) {
  return Math.round(number * 100) / 100;
}

function displayAlert(amount) {
  $(".alert-balance-amount").text(amount);
  $(".alert-update-balance").fadeIn(1200).delay(3000).fadeOut(1200);
}

function updateBalance(amount) {
  $("#balance-result").text(amount);
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
