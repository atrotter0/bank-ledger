$(document).ready(function() {
  $('.modal').on('shown.bs.modal', function() {
    $(this).find('[autofocus]').focus();
  });
});
