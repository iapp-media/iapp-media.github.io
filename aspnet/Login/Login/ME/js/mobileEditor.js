'use strict';
var current = 0,
  width=100,
  height=100;

(function() {

  // $(function() {

  // Demo
  // -------------------------------------------------------------------------

  (function() {
    var $image = $('.img-container > img'),
      $dataX = $('#dataX'),
      $dataY = $('#dataY'),
      $dataHeight = $('#dataHeight'),
      $dataWidth = $('#dataWidth'),
      $dataRotate = $('#dataRotate'),
      options = {
        // strict: false,
        // responsive: false,
        // checkImageOrigin: false

        // modal: false,
        // guides: false,
        // highlight: false,
        // background: false,

        // autoCrop: false,
        autoCropArea: 0.9,
        dragCrop: false,
        movable: false,
        resizable: false,
        // rotatable: false,
        // zoomable: false,
        // touchDragZoom: false,
        // mouseWheelZoom: false,

        // minCanvasWidth: 320,
        // minCanvasHeight: 180,
        // minCropBoxWidth: 480,
        // minCropBoxHeight: 90,
        // minContainerWidth: 320,
        // minContainerHeight: 180,

        // build: null,
        // built: null,
        // dragstart: null,
        // dragmove: null,
        // dragend: null,
        // zoomin: null,
        // zoomout: null,

        aspectRatio: (width / height),
        preview: '.img-preview',
        crop: function(data) {
          $dataX.val(Math.round(data.x));
          $dataY.val(Math.round(data.y));
          $dataHeight.val(Math.round(data.height));
          $dataWidth.val(Math.round(data.width));
          $dataRotate.val(Math.round(data.rotate));
        }
      };
    $image.on({
      'build.cropper': function(e) {
        console.log(e.type);
      },
      'built.cropper': function(e) {
        console.log(e.type);
        $('#uploading').hide();
      },
      'dragstart.cropper': function(e) {
        console.log(e.type, e.dragType);
      },
      'dragmove.cropper': function(e) {
        console.log(e.type, e.dragType);
      },
      'dragend.cropper': function(e) {
        console.log(e.type, e.dragType);
      },
      'zoomin.cropper': function(e) {
        console.log(e.type);
      },
      'zoomout.cropper': function(e) {
        console.log(e.type);
      }
    }).cropper(options).cropper('setAspectRatio', width / height);

    // Methods
    $(document.body).on('click', '[data-method]', function() {
      var data = $(this).data(),
        $target,
        result;
      if (data.method) {
        data = $.extend({}, data); // Clone a new one

        if (typeof data.target !== 'undefined') {
          $target = $(data.target);

          if (typeof data.option === 'undefined') {
            try {
              data.option = JSON.parse($target.val());
            } catch (e) {
              console.log(e.message);
            }
          }
        }

        //
        result = $image.cropper(data.method, data.option);
        // $('.img-container').hide();

        if (data.method === 'rotate') {
          $image.cropper('rotate', 90);
        }
        // console.log(result);
        if (data.method === 'getCroppedCanvas') {
          document.getElementById('preview').src = result.toDataURL('image/jpeg', 0.6);
          $('.img-container').hide();
          $('.preview-container').show();
          $('.rotate-btn').hide();
        }

        if ($.isPlainObject(result) && $target) {
          try {
            $target.val(JSON.stringify(result));
          } catch (e) {
            console.log(e.message);
          }
        }

      }
    });
    $(document.body).on('keydown', function(e) {

      switch (e.which) {
        case 37:
          e.preventDefault();
          $image.cropper('move', -1, 0);
          break;

        case 38:
          e.preventDefault();
          $image.cropper('move', 0, -1);
          break;

        case 39:
          e.preventDefault();
          $image.cropper('move', 1, 0);
          break;

        case 40:
          e.preventDefault();
          $image.cropper('move', 0, 1);
          break;
      }

    });


    // Import image
    var $inputImage = $('#inputImage'),
      URL = window.URL || window.webkitURL,
      blobURL;

    if (URL) {
      $inputImage.change(function() {
        $('#uploading').show();
        var files = this.files,
          file;
        if (files && files.length) {
          file = files[0];
          if (/^image\/\w+$/.test(file.type)) {
            blobURL = URL.createObjectURL(file);
            $image.one('built.cropper', function() {
              URL.revokeObjectURL(blobURL); // Revoke when load complete
            }).cropper('reset', true).cropper('replace', blobURL).cropper('setAspectRatio', width / height);
            $inputImage.val('');
            $('#cut').attr('disabled', false);
          } else {
            showMessage('Please choose an image file.');
          }
        }

      });
    } else {
      $inputImage.parent().remove();
    }
  }());
})();


function compress() {
  document.getElementById('preview').src = jic.compress(document.getElementById('preview'), width, height, 'jpg').src;
  document.getElementById('Tbase64').setAttribute('value', document.getElementById('preview').src.replace(/^data:image\/(png|jpeg);base64,/, ''));
  //document.getElementById('p' + current).src = document.getElementById('preview').src;
  // document.getElementById('Tbase64-' + current).setAttribute('value', document.getElementById('Tbase64').value);
  //document.getElementById('p' + current).className = document.getElementById('p' + current).className.replace(/(?:^|\s)changestyle(?!\S)/g, '');
  $('.cropper-container').remove();

    // sendImageToParse(current, document.getElementById('Tbase64').value);

  //$.ajax({
  //    type: "POST",
  //    url: "Svim.aspx",
  //    data: "i=" + current + "&t=" + encodeURIComponent(document.getElementById('Tbase64').value),
  //    cache: false,
  //    success: function (imgurl) {
  //        document.getElementById('p' + current).src = "../" + imgurl;
  //    },
  //    error: function (ss) {
  //        alert(ss);
  //    }
  //});

}

//function setCurrent(number, w, h) {
//  current = number;
//  width = w;
//  height = h;
//  document.getElementById('CurrentId').setAttribute('value', current);
//  // $image.cropper("setAspectRatio", width / height);
//}
