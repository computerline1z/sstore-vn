function Pager(tableName, itemsPerPage) {
    this.tableName = tableName;
    this.itemsPerPage = itemsPerPage;
    this.currentPage = 1;
    this.pages = 0;
    this.totalrecs = 0;
    this.inited = false;
    
    this.showRecords = function(from, to) {        
        var rows = document.getElementById(tableName).rows;
        // i starts from 1 to skip table header row
        for (var i = 1; i < rows.length; i++) {
            if (i < from || i > to)  
                rows[i].style.display = 'none';
            else
                rows[i].style.display = '';
        }
    }
    
    this.showPage = function(pageNumber) {
    	if (! this.inited) {
    		//alert("not inited");
    		return;
    	}

        var oldPageAnchor = document.getElementById('pg'+this.currentPage);
        if(oldPageAnchor!=null)
            oldPageAnchor.className = '';
        
        this.currentPage = pageNumber;
        var newPageAnchor = document.getElementById('pg'+this.currentPage);
        if(newPageAnchor!=null)
            newPageAnchor.className = 'selected';
        
        var from = (pageNumber - 1) * itemsPerPage + 1;
        var to = from + itemsPerPage - 1;
        this.showRecords(from, to);
    }   
    
    this.prev = function() {
        if (this.currentPage > 1)
            this.showPage(this.currentPage - 1);
    }
    
    this.next = function() {
        if (this.currentPage < this.pages) {
            this.showPage(this.currentPage + 1);
        }
    }                        
    
    this.init = function() {
        var rows = document.getElementById(tableName).rows;
        var records = (rows.length - 1); 
        this.totalrecs = records;
        this.pages = Math.ceil(records / itemsPerPage);
        this.inited = true;
    }

    this.showPageNav = function(pagerName, positionId) {
    	if (! this.inited) {
    		//alert("not inited");
    		return;
    	}
    	var element = document.getElementById(positionId);
    	var pagerHtml='';
    	if(this.pages>1)
    	{
    	    pagerHtml += '<a href="javascript:void(0)" onclick="' + pagerName + '.prev();">&#171 prev</a>';
            for (var page = 1; page <= this.pages; page++) 
                pagerHtml += '<a id="pg' + page + '" href="javascript:void(0)" onclick="' + pagerName + '.showPage(' + page + ');">' + page + '</a>';
            pagerHtml += '<a href="javascript:void(0)" onclick="' + pagerName + '.next();">next &#187;</a>';            
        }
        element.innerHTML = pagerHtml;
    }
}