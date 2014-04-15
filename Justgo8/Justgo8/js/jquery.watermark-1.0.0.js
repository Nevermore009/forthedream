/*
 *
 * jQuery Watermarks 1.0.0
 * 
 * Date: July 26 2012
 * Source: www.tectual.com.au, www.arashkarimzadeh.com
 * Author: Arash Karimzadeh (arash@tectual.com.au)
 *
 * Copyright (c) 2012 Tectual Pty. Ltd.
 * http://www.opensource.org/licenses/mit-license.php
 *
 */
(function($){
 
$.fn.watermarks = function(options){
  
  var opts = $.extend( {}, $.fn.watermarks.options, options );

  $('[data-type=watermark]', this).each(
    function(){
      var $this = $(this);
      var focus = function(){
        $($this.data('for')).add($this).addClass(opts.focusedClass);
      }
      $($this.data('for'))
        .blur(
          function(){
            var $t = $(this);
            ($t.val()=='')
              ? $t.add($this).removeClass(opts.focusedClass)
              : $t.add($this).addClass(opts.focusedClass);
          }
        ).keyup(
          function(){
            var $t = $(this);
            ($t.val()=='')
              ? $t.add($this).removeClass(opts.filledClass)
              : $t.add($this).addClass(opts.filledClass);
          }
        ).blur().keyup().focus(focus).click(focus);
        $this.click(function(){$($this.data('for')).focus()});
    }
  );
  return this;
}
$.fn.watermarks.options = {
  focusedClass: 'focused', /* CSS Class: Class which is assigned when it is  */
  filledClass: 'filled' /* CSS Class: Class which is assigned when it is filled */
}

})(jQuery);


