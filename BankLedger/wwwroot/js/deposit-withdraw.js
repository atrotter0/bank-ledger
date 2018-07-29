function clearInput(element) {
  $(element).val("");
}

function runDeposit(inputAmount) {
  $.ajax({
    type: "POST",
    data: { amount: inputAmount },
    url: '/account/deposit/' + inputAmount,
    success: function(result) {
      console.log(result);
      displayDepositMsg();
      displayUpdatedBalance(inputAmount, result);
    },
    error: function(err) {
      console.log("Error: " + JSON.stringify(err));
    }
  });
}

function runWithdrawal(inputAmount) {
  $.ajax({
    type: "POST",
    data: { amount: inputAmount },
    url: '/account/withdraw/' + inputAmount,
    success: function(result) {
      console.log(result);
      displayWithdrawMsg();
      displayUpdatedBalance(inputAmount, result);
    },
    error: function(err) {
      console.log("Error: " + JSON.stringify(err));
    }
  });
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
    var amount = parseFloat($("#deposit-amount").val());
    console.log(amount);
    clearInput("#deposit-amount");
    runDeposit(amount);
  });

  $("#make-withdrawal").click(function() {
    var amount = parseFloat($("#withdraw-amount").val());
    console.log(amount);
    clearInput("#withdraw-amount");
    runWithdrawal(amount);
  });
});
