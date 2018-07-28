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
      roundedAmount = roundTwoDecimals(result.amount);
      displayDepositMsg();
      displayAlert(amount);
      updateBalance(roundedAmount);
    },
    error: function(err) {
      console.log("Error: " + JSON.stringify(err));
    }
  });
}

function runWithdrawal(amount) {
  $.ajax({
    type: "POST",
    data: { amount: amount },
    url: '/account/withdraw/' + amount,
    success: function(result) {
      console.log(result);
      roundedAmount = roundTwoDecimals(result.amount);
      displayWithdrawMsg();
      displayAlert(amount);
      updateBalance(roundedAmount);
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

function displayAlert(amount) {
  $(".alert-balance-amount").text(amount);
  $(".alert-update-balance").fadeIn(1200).delay(3000).fadeOut(1200);
}

function updateBalance(amount) {
  $("#balance-result").text(amount);
}

function roundTwoDecimals(number) {
  return Math.round(number * 100) / 100;
}

$(document).ready(function() {
  $("#make-deposit").click(function() {
    var amount = parseFloat($("#deposit-amount").val());
    clearInput("#deposit-amount");
    runDeposit(amount);
  });

  $("#make-withdrawal").click(function() {
    var amount = parseFloat($("#withdraw-amount").val());
    clearInput("#withdraw-amount");
    runWithdrawal(amount);
  });
});
