var gulp = require('gulp'),
    sass = require('gulp-sass');

gulp.task('build-css', function () {
    return gulp
        .src('../sass/**/*.scss')
        .pipe(sass())
        .pipe(gulp.dest('../css'));
});

//Default Task
gulp.task('default', ['build-css']);