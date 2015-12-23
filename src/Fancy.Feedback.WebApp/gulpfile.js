/// <binding Clean='clean' />
"use strict";

var gulp = require("gulp"),
    rimraf = require("rimraf"),
    livereload = require('gulp-livereload'),
    less = require("gulp-less"),
    concat = require("gulp-concat"),
    cssmin = require("gulp-cssmin"),
    uglify = require("gulp-uglify");

var paths = {
    webroot: "./wwwroot/"
};

paths.js = paths.webroot + "js/**/*.js";
paths.minJs = paths.webroot + "js/**/*.min.js";
paths.css = paths.webroot + "css/**/*.css";
paths.minCss = paths.webroot + "css/**/*.min.css";
paths.concatJsDest = paths.webroot + "js/";
paths.fontDest = paths.webroot + "fonts/";
paths.concatCssDest = paths.webroot + "css/";
paths.imagesDest = paths.webroot + "images/";

gulp.task("clean:js", function (cb) {
    rimraf(paths.concatJsDest, cb);
});

gulp.task("clean:font", function (cb) {
    rimraf(paths.fontDest, cb);
});

gulp.task("clean:css", function (cb) {
    rimraf(paths.concatCssDest, cb);
});

gulp.task("clean:images", function (cb) {
    rimraf(paths.imagesDest, cb);
});

gulp.task("clean:infrastructure", function (cb) {
    rimraf(paths.webroot + "Web.config", cb);
    rimraf(paths.webroot + "favicon.ico", cb);
});

gulp.task("clean", ["clean:js", "clean:font", "clean:css", "clean:images", "clean:infrastructure"]);

gulp.task("min:js", function () {

    // Get all reguired sources bundle them
    gulp.src([
                './bower_components/jquery/dist/jquery.js',
                './bower_components/jquery-validation/dist/jquery.validate.js',
                './bower_components/jquery-validation/dist/additional-methods.js',
                './bower_components/jquery-validation-unobtrusive/jquery.validate.unobtrusive.js',
                './bower_components/bootstrap/dist/js/bootstrap.js'
            ], { base: "." })
        .pipe(concat(paths.concatJsDest + "site.min.js"))
        .pipe(uglify())
        .pipe(gulp.dest("."))
        .pipe(livereload());
});

gulp.task('min:css', function () {

    // Move bootstrap fonts to wwwroot
    gulp.src('./bower_components/bootstrap/fonts/**/*.*')
		.pipe(gulp.dest(paths.fontDest));

    // Build styles and move to wwwroot
    gulp.src('./Web/less/styles.less')
		.pipe(less())
        .pipe(cssmin())
		.pipe(gulp.dest(paths.concatCssDest))
        .pipe(livereload());
});

gulp.task("images", function () {

    // Move images to wwwroot
    gulp.src('./Web/images/**/*.*')
		.pipe(gulp.dest(paths.imagesDest));

});

gulp.task("infrastructure", function () {

    // Move infrastructure items to wwwroot
    gulp.src(["./Web/favicon.ico", "./Web/Web.config"])
		.pipe(gulp.dest(paths.webroot));

});

gulp.task("build", ["min:js", "min:css", "images", "infrastructure"]);

gulp.task("watch", function () {
    livereload.listen();
    gulp.watch(["./Web/less/*.less", "./Views/**/*.cshtml"], ["min:css"]);
});
