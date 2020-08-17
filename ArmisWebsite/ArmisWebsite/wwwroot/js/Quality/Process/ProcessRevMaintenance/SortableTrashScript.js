new Sortable(sortableTrash,
    {
        group: {
            name: 'steps'
        },
        onAdd: function (evt) {
            var el = evt.item;
            el.parentNode.removeChild(evt.item);
        }
    });