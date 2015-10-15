var jic = {


  compress: function(source_img_obj, width, height, output_format) {

    var mime_type = "image/jpeg";
    if (typeof output_format !== "undefined" && output_format == "png") {
      mime_type = "image/png";
    }


    var cvs = document.createElement('canvas');
    if (source_img_obj.naturalWidth > width) {
      cvs.height = height;
      cvs.width = width;
    } else {
      cvs.width = source_img_obj.naturalWidth;
      cvs.height = source_img_obj.naturalHeight;
    }
    // console.log(cvs);
    var ctx = cvs.getContext("2d");
    ctx.fillStyle = "rgba(255,255,255,1)";
    ctx.fillRect(0, 0, cvs.width, cvs.height);
    ctx.drawImage(source_img_obj, 0, 0, cvs.width, cvs.height);
    var newImageData = cvs.toDataURL(mime_type, 0.6);
    var result_image_obj = new Image();
    result_image_obj.src = newImageData;
    return result_image_obj;
  },


};
