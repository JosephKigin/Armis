new Sortable(sortableCurrentSteps,
    {
        group: {
            name: 'steps'
        },
        handle: '.handle',
        animation: 150,
        ghostClass: 'bg-warning',

        onSort: function (evt) {
            assignStepSeqNumbers();
        },

        onAdd: function (evt) {
            console.log("You have hit onAdd in CurrentStepsSortable");

            //This entire section up to the assignStepSeqNumbers() call is just to make sure the collapsables stay assigned to the correct collapse sections when a step is moved from allSteps to currentSteps.
            evt.item.id = evt.item.id.replace("all", "current");
            var allStepListItemChildren = evt.item.childNodes;
            for (var i = 0; i < allStepListItemChildren.length; i++) {
                //if the child element has an id, if not then it doesn't need to be changed at all.
                if (allStepListItemChildren[i].id != undefined) {
                    //if the step comes from the AllStepList, the <a> tag will have an id of "allStepDetails-(stepId)"
                    if (allStepListItemChildren[i].id.startsWith("allStepHeader")) {

                        var theAnchors = allStepListItemChildren[i].getElementsByTagName("a");
                        theAnchors[0].id = theAnchors[0].id.replace("all", "current");
                        theAnchors[0].dataset.target = theAnchors[0].dataset.target.replace("all", "current");//The collapse trigger anchor
                        theAnchors[1].id = theAnchors[1].id.replace("all", ""); //The operation anchor
                        theAnchors[1].innerHTML += "<i class='far fa-object-group'></i>";
                    }
                    //if the step comes from the AllStepList, the collapsable section will have an id of allStepDetails-(stepId)
                    if (allStepListItemChildren[i].id.startsWith("allStepDetails")) {
                        allStepListItemChildren[i].id = allStepListItemChildren[i].id.replace("all", "current");
                    }
                }
            }

            //Renaming the input placeholders
            var inputs = evt.item.getElementsByTagName("input");
            for (var i = 0; i < inputs.length; i++) {
                inputs[i].id = inputs[i].id.replace("all", "current");
            }

            assignStepSeqNumbers();
        }
    });