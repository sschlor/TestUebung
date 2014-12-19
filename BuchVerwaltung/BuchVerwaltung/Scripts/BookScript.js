$(document).ready(function () {
    initTree();
})

function initTree() {
    var prop = {
        initAjax: {
            url: "Home/LadeTree"
        },
        onLazyRead: loadSubTree,
        onClick: OnNodeClick
    };
    $("#tree").dynatree(prop);

    var x = {
        url: "Home/LadeGrid",
        datatype: "json",
        mtype: "GET",
        colNames: ["ID", "Titel", "Autor", "Verlag", "Sprache", "Seiten"],
        colModel: [
            { name: "ID", index: "ID", editable: false, hidden: false, width: 150 },
            { name: "Titel", index: "Titel", editable: false, hidden: false, width: 150 },
            { name: "Autor", index: "Autor", editable: false, hidden: false, width: 150 },
            { name: "Verlag", index: "Verlag", editable: false, hidden: false, width: 150 },
            { name: "Sprache", index: "Sprache", editable: false, hidden: false, width: 150 },
            { name: "Seiten", index: "Seiten", editable: false, hidden: false, width: 150 }
        ],
        pager: $("#pager"),
        rowNum: 10,
        rowList: [10, 20],
        sortname: "Titel",
        width: 900,
        caption: "Book Overview"
    };

    $("#grid").jqGrid(x);
}

function loadSubTree(node) {
    var prop = {
        url: "Home/LadeSubTree",
        data: { "nodeKey": node.data.key }
    }

    node.appendAjax(prop);
}

function OnNodeClick(node, event)
{
    if(node.getLevel()==2)
    {
        
    }
}