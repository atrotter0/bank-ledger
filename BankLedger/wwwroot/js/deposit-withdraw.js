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
      displayDepositMsg();
      displayUpdatedBalance(result);
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
      displayWithdrawMsg();
      displayUpdatedBalance(result);
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

function displayUpdatedBalance(result) {
  roundedAmount = roundTwoDecimals(result.amount);
  displayAlert(amount);
  updateBalance(roundedAmount);
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
    clearInput("#deposit-amount");
    runDeposit(amount);
  });

  $("#make-withdrawal").click(function() {
    var amount = parseFloat($("#withdraw-amount").val());
    clearInput("#withdraw-amount");
    runWithdrawal(amount);
  });
});
