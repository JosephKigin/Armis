new Sortable(sortableAllSteps,
    {
        group: {
            name: 'steps',
            pull: 'clone'
        },
        handle: '.handle',
        animation: 150,
        ghostClass: 'bg-warning',
        sort: false,
        onStart: function (evt) {
            evt.item.getElementsByTagName("div")[0].classList = "collapse";
        },
        onAdd: function (evt) {
            var el = evt.item;
            el.parentNode.removeChild(evt.item);
        }
    });