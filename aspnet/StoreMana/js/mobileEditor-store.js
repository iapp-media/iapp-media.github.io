'use strict';
var current = 0,
  width,
  height,
      Todo;

(function () {

    // $(function() {

    // Demo
    // -------------------------------------------------------------------------

    (function () {
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
              crop: function (data) {
                  $dataX.val(Math.round(data.x));
                  $dataY.val(Math.round(data.y));
                  $dataHeight.val(Math.round(data.height));
                  $dataWidth.val(Math.round(data.width));
                  $dataRotate.val(Math.round(data.rotate));
              }
          };
        $image.on({
            'build.cropper': function (e) {
                console.log(e.type);
            },
            'built.cropper': function (e) {
                console.log(e.type);
                $('.uploading').hide();
            },
            'dragstart.cropper': function (e) {
                console.log(e.type, e.dragType);
            },
            'dragmove.cropper': function (e) {
                console.log(e.type, e.dragType);
            },
            'dragend.cropper': function (e) {
                console.log(e.type, e.dragType);
            },
            'zoomin.cropper': function (e) {
                console.log(e.type);
            },
            'zoomout.cropper': function (e) {
                console.log(e.type);
            }
        }).cropper(options).cropper('setAspectRatio', width / height);

        // Methods
        $(document.body).on('click', '[data-method]', function () {
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
        $(document.body).on('keydown', function (e) {

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
            $inputImage.change(function () {
                $('.uploading').show();
                var files = this.files,
                  file;
                console.log(files);

                if (files && files.length) {
                    file = files[0];
                    if (/^image\/\w+$/.test(file.type)) {
                        var reader = new FileReader();
                        //rotate image according to orientation
                        console.log(file);
                        var orientation;
                        EXIF.getData(file, function () {
                            orientation = EXIF.getTag(this, 'Orientation');
                        });
                        reader.readAsDataURL(file);
                        reader.onload = function (e) {
                            var aImg = document.createElement('img');
                            aImg.onload = function () {
                                // draw the aImg onto the canvas
                                var canvas = document.createElement('canvas');

                                // var canvas = document.getElementById('cvs');
                                var ctx = canvas.getContext('2d');
                                canvas.width = aImg.width;
                                canvas.height = aImg.height;

                                if (!orientation || orientation > 8) {
                                    canvas.width = aImg.width;
                                    canvas.height = aImg.height;
                                }
                                if (orientation > 4) {
                                    canvas.width = aImg.height;
                                    canvas.height = aImg.width;
                                }
                                switch (orientation) {
                                    case 2:
                                        // horizontal flip
                                        ctx.translate(aImg.width, 0);
                                        ctx.scale(-1, 1);
                                        break;
                                    case 3:
                                        // 180° rotate left
                                        ctx.translate(aImg.width, aImg.height);
                                        ctx.rotate(Math.PI);
                                        break;
                                    case 4:
                                        // vertical flip
                                        ctx.translate(0, aImg.height);
                                        ctx.scale(1, -1);
                                        break;
                                    case 5:
                                        // vertical flip + 90 rotate right
                                        ctx.rotate(0.5 * Math.PI);
                                        ctx.scale(1, -1);
                                        break;
                                    case 6:
                                        // 90° rotate right
                                        ctx.rotate(0.5 * Math.PI);
                                        ctx.translate(0, -aImg.height);
                                        break;
                                    case 7:
                                        // horizontal flip + 90 rotate right
                                        ctx.rotate(0.5 * Math.PI);
                                        ctx.translate(aImg.width, -aImg.height);
                                        ctx.scale(-1, 1);
                                        break;
                                    case 8:
                                        // 90° rotate left
                                        ctx.rotate(-0.5 * Math.PI);
                                        ctx.translate(-aImg.width, 0);
                                        break;
                                }
                                ctx.drawImage(aImg, 0, 0);
                                // make the jpeg image
                                blobURL = canvas.toDataURL('image/jpeg', 0.6);
                                $image.one('built.cropper', function () {
                                    URL.revokeObjectURL(blobURL); // Revoke when load complete
                                }).cropper('reset', true).cropper('replace', blobURL).cropper('setAspectRatio', width / height);
                                $inputImage.val('');
                                $('#cut').attr('disabled', false);
                            };
                            aImg.src = e.target.result;

                        };
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


    $.ajax({
        type: "POST",
        url: "Svim.aspx",
        data: "d=store&t=" + encodeURIComponent(document.getElementById('Tbase64').value),
        cache: false,
        success: function (imgurl) { 
            document.getElementById('psimg').src = document.getElementById('preview').src; 
            //$('#psimg').src = imgurl;
            //alert(imgurl);
        },
        error: function (ss) {
            //  alert('2');
        }
    });

     /// document.getElementById('Tbase64-' + current).setAttribute('value', document.getElementById('Tbase64').value);
    //document.getElementById('p' + current).className = document.getElementById('p' + current).className.replace(/(?:^|\s)changestyle(?!\S)/g, '');
    $('.cropper-container').remove();

    // sendImageToParse(current, document.getElementById('Tbase64').value);



}

function setCurrent() {
    //current = number;
    width = 980;
    height = 320; 
    //document.getElementById('CurrentId').setAttribute('value', current);
    // $image.cropper("setAspectRatio", width / height);
}
