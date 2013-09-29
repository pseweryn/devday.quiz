$(function() {

    var Quiz = {
        init: function () {
            $('.questionContainer').each(function() {
                $(this).find('.track-content :not(:first)').hide();
            });
            
            $('.track-nav div').click(function(event) {
                event.preventDefault();
                $('.track-content').hide();
                $('.track-nav .current').removeClass("current");
                var clicked = $(this).attr('class');
                $('.track-content.' + clicked).fadeIn('slow');
                $(this).addClass('current');
            }).eq(0).addClass('current');

            $('.btnNext').click(function() {
                $(this).parents('.questionContainer').fadeOut(100, function() {
                    $(this).next().show("slide", { direction: "right" }, 500);
                });
            });

            $('.btnPrev').click(function() {
                $(this).parents('.questionContainer').fadeOut(100, function() {
                    $(this).prev().show("slide", { direction: "left" }, 500);
                });
            });

            $(document.body).on('click', '.btnShowResult', function () {
                var nick = $("input[name='nick']").val();
                var arr = $('input[type=radio]:checked');
                var ans = Quiz.userAnswers = [];
                for (var i = 0, ii = arr.length; i < ii; i++) {
                    ans.push(arr[i].getAttribute('id'));
                }
                var quizData = '{nickname: "' + nick + '", ' + 'results: "' + ans + '"}';
                $.ajax({
                    url: '/Quiz/Finish',
                    type: 'POST',
                    data: quizData,
                    datatype: 'JSON',
                    contentType: 'application/json',
                    success: function(result) {
                        $('.questionContainer.last').hide();
                        var resultSet = '<div class="totalScore">' + result + '</div>' +
                            '<div>Now go ahead and check the <a href="/Quiz/Results">results</a></div>';
                        $('#resultKeeper').html(resultSet).show();
                    },
                    error: function (xhr, ajaxOptions, thrownError) {
                        $('.questionContainer.last').hide();
                        var resultSet = '<div class="general-error">Something went wrong</div>' +
                            '<div class="general-error">Please try again in a moment</div>' +
                            '<div><a class="btnShowResult small button retry">Retry </a></div>';
                        $('#resultKeeper').html(resultSet).show();
                        console.log('something went wrong:');
                        console.log(xhr);
                        console.log(thrownError);
                    }
                });
            });

            $("input[name='start']").click(function() {
                $('.intro').hide();
                $('.track-nav').show();
                $('.questionContainer.first').show("slide", { direction: "right" }, 500);
            });

            $("input[name='nick']").keyup(function() {
                if ($(this).val()) {
                    $("input[name='start']").removeAttr('disabled');
                } else {
                    $("input[name='start']").attr('disabled', 'disabled');
                }
            });
            $('input[type=radio]').change(function() {
                if ($(this).is(':checked')) {
                    $(this).closest('ul').find('.radioLabel').removeClass('checked');
                    $(this).parent().find('.radioLabel').addClass('checked');
                }
            });
            
            $('.accordion').accordion({
                header: 'h4',
                active: false,
                collapsible: true,
                icons: {
                    header: 'acc-icon acc-collapsed',
                    headerSelected: 'acc-icon acc-expanded'
                }
            });
            $('.menu-icon').click(function() {
                $('nav ul').slideToggle();
            });
        }
    };
    Quiz.init();
});