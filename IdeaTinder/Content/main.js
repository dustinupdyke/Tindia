function postIt(id, like) {
    $.ajax({
        type: 'POST',
        url: './api/votes',
        data: JSON.stringify({ "IdeaId": id, "Like": like, "CreatedBy": $("#createdby").val() }),
        contentType: "application/json",
        dataType: 'json'
    });
}

function fill() {
    $.ajax({
        type: 'GET',
        url: './api/ideas',
        //data: JSON.stringify({ "IdeaId": id, "Like": like, "CreatedBy": $("#createdby").val() }),
        contentType: "application/json",
        dataType: 'json'
    }).done(function (data) {
        $.each(data, function (i, o) {
            $('#tinderslide-items').append('<li class="pane" data-id="' + o.Id + '"><div>' + o.Name + '</div><div class="like"></div><div class="dislike"></div></li>');
            ideas++;
        });

        if (ideas < 1)
            window.location.href = "waiting.aspx";

        /**
         * jTinder initialization
         */
        $("#tinderslide").jTinder({
            // dislike callback
            onDislike: function (item) {
                var id = $(item).attr("data-id");
                postIt(id, false);
                // set the status text
                $('#status').html('Dislike idea ' + id);
                ideas--;

                console.log(ideas);
                if (ideas < 1)
                    window.location.href = "waiting.aspx";
            },
            // like callback
            onLike: function (item) {
                var id = $(item).attr("data-id");
                postIt(id, true);
                // set the status text
                $('#status').html('Like idea ' + id);
                ideas--;

                console.log(ideas);
                if (ideas < 1)
                    window.location.href = "waiting.aspx";
            },
            animationRevertSpeed: 200,
            animationSpeed: 400,
            threshold: 1,
            likeSelector: '.like',
            dislikeSelector: '.dislike'
        });

        /**
         * Set button action to trigger jTinder like & dislike.
         */
        $('.actions .like, .actions .dislike').click(function (e) {
            e.preventDefault();
            $("#tinderslide").jTinder($(this).attr('class'));
            ideas--;
        });
    });
}

var ideas = 0;

fill();

$('#add-idea-add').click(function (e) {
    e.preventDefault();
    $.ajax({
        type: 'POST',
        url: './api/ideas',
        data: JSON.stringify({ "Name": $('#add-idea-text').val(), "CreatedBy": $("#createdby").val() }),
        contentType: "application/json",
        dataType: 'json'
    }).done(function (data) {
        $('#add-idea-text').val('');
    });
});