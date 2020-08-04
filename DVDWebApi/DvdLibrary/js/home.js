$(document).ready(function () {
	loadDvds();
	
$('#edit-button').click(function (event) {
	    $.ajax({
        type: 'PUT',
        url: 'http://localhost:50215/dvd/' + $('#edit-dvdId').val(),
        data: JSON.stringify({
			dvdId: $('#edit-dvdId').val(),			
            title:  $('#edit-title').val(),
            releaseYear: $('#edit-releaseYear').val(),
            director: $('#edit-director').val(),
            rating:  $('#edit-rating').val(),
            notes:  $('#edit-notes').val()
          }),
		  headers: {
             'Accept': 'application/json',
             'Content-Type': 'application/json'
           },	
           'dataType': 'json',
            success: function() {
			    // clear errorMessages
				$('#errorMessages').empty();
				hideEditForm();
				loadDvds();

			},
           error: function() {
             $('#errorMessages')
                .append($('<li>')
                .attr({class: 'list-group-item list-group-item-danger'})
                .text('Error calling web service.  Please try again later.'));
            }
		})
	});
	
   $('#add-button').click(function (event) {

        $.ajax({
            type: 'POST',
            url: 'http://localhost:50215/dvd',
            data: JSON.stringify({
                title: $('#add-title').val(),
                director: $('#add-director').val(),
                releaseYear: $('#add-releaseYear').val(),
                rating: $('#add-rating').val(),
                notes: $('#add-notes').val()
            }),
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            'dataType': 'json',
            success: function() {
              
                $('#errorMessages').empty();
              
                $('#add-title').val('');
                $('#add-director').val('');
                $('#add-releaseYear').val('');
                $('#add-rating').val('');
                $('#add-notes').val('');
				
				hideCreateForm();
				$('#dvdTable').show();
				loadDvds();
            },
            error: function() {
                $('#errorMessages')
                   .append($('<li>')
                   .attr({class: 'list-group-item list-group-item-danger'})
                   .text('Error calling web service.  Please try again later.'));
            }
		});
    });
});


function  showCreateForm(){
	$('#createDvdFormDiv').show();
	$('#dvdTable').hide();
	 
}
function  cancelDisplayForm(){
	$('#displayFormDiv').hide();
	location.reload();
}
function hideCreateForm() {
	$('#createDvdFormDiv').hide();
}
function loadDvds() {
    // we need to clear the previous content so we don't append to it
    clearDvdTable();

    // grab the the tbody element that will hold the rows of contact information
    var dvdRows = $('#dvdRows');

    $.ajax ({
        type: 'GET',
        url: 'http://localhost:50215/dvds/all',
        success: function (data, status) {
            $.each(data, function (index, dvd) {
                var title = dvd.title;
                var releaseYr = dvd.releaseYear;
                var id = dvd.dvdId;
				var dir = dvd.director;
				var rtg = dvd.rating;

                var row = '<tr>';
					row += '<td><a onclick="showDisplayForm(' + id + ')">' + title + '</a></td>';
                    row += '<td>' + releaseYr + '</td>';
					row += '<td>' + dir + '</td>';
					row += '<td>' + rtg + '</td>';
                    row += '<td><a onclick="showEditForm(' + id + ')">Edit</a>  |  ';
                    row += '<a onclick="deleteDvd(' + id + ')">Delete</a></td>';
                    row += '</tr>';
                dvdRows.append(row);
				hideCreateForm();
            });
			
        },
        error: function() {
            $('#errorMessages')
                .append($('<li>')
                .attr({class: 'list-group-item list-group-item-danger'})
                .text('Error calling web service.  Please try again later.'));
        }
    });

}

function loadSearchDvds() {
    // we need to clear the previous content so we don't append to it
    clearDvdTable();

    // grab the the tbody element that will hold the rows of contact information
    var dvdRows = $('#dvdRows');
	
	var select = $( "#search-Category" ).val(); 
	var searchTerm = $( "#searchTerm" ).val();

    $.ajax ({
        type: 'GET',
        url: 'http://localhost:50215/dvd/'+select+'/'+searchTerm,
        success: function (data, status) {
            $.each(data, function (index, dvd) {
                var title = dvd.title;
                var releaseYr = dvd.releaseYear;
                var id = dvd.dvdId;
				var dir = dvd.director;
				var rtg = dvd.rating;

                var row = '<tr>';
					row += '<td><a onclick="showDisplayForm(' + id + ')">' + title + '</a></td>';
                    row += '<td>' + releaseYr + '</td>';
					row += '<td>' + dir + '</td>';
					row += '<td>' + rtg + '</td>';
                    row += '<td><a onclick="showEditForm(' + id + ')">Edit</a>  |  ';
                    row += '<a onclick="deleteDvd(' + id + ')">Delete</a></td>';
                    row += '</tr>';
                dvdRows.append(row);
				
            });
			
        },
        error: function() {
            $('#errorMessages')
                .append($('<li>')
                .attr({class: 'list-group-item list-group-item-danger'})
                .text('Error calling web service.  Please try again later.'));
        }
    });

}
function clearDvdTable() {
    $('#dvdRows').empty();
}




function deleteDvd(dvdId) {
	var checkDelete = confirm('Are you sure you want to delete this Dvd from your collection?');
	if (checkDelete == true ){
    $.ajax ({
        type: 'DELETE',
        url: "http://localhost:50215/dvd/" + dvdId,
        success: function (status) {
            loadDvds();
        }
    })

	}	else 
		return false;
}
<!--------------------------------------------->
function showEditForm(id) {
    // clear errorMessages
    $('#errorMessages').empty();
    // get the contact details from the server and then fill and show the
    // form on success
    $.ajax({
        type: 'GET',
        url: 'http://localhost:50215/dvd/' + id,
        success: function(data, status) {
              $('#edit-dvdId').val(data.dvdId);			
              $('#edit-title').val(data.title);
              $('#edit-releaseYear').val(data.releaseYear);
              $('#edit-director').val(data.director);
              $('#edit-rating').val(data.rating);
              $('#edit-notes').val(data.notes);
          },
          error: function() {
            $('#errorMessages')
               .append($('<li>')
               .attr({class: 'list-group-item list-group-item-danger'})
               .text('Error calling web service.  Please try again later.'));
          }
    });
    $('#dvdTable').hide();
    $('#editDvdFormDiv').show();
}
function showDisplayForm(id) {
    // clear errorMessages
    $('#errorMessages').empty();
    // get the contact details from the server and then fill and show the
    // form on success
    $.ajax({
        type: 'GET',
        url: 'http://localhost:50215/dvd/' + id,
        success: function(data, status) {
              $('#display-dvdId').val(data.dvdId);			
			  $('#display-title').val(data.title);
              $('#display-releaseYear').val(data.releaseYear);
              $('#display-director').val(data.director);
              $('#display-rating').val(data.rating);
              $('#display-notes').val(data.notes);
          },
          error: function() {
            $('#errorMessages')
               .append($('<li>')
               .attr({class: 'list-group-item list-group-item-danger'})
               .text('Error calling web service.  Please try again later.'));
          }
    });
    $('#dvdTable').hide();
    $('#displayFormDiv').show();	

}


function hideEditForm() {
    // clear errorMessages
    $('#errorMessages').empty();
    // clear the form and then hide it
    $('#edit-title').val('');
    $('#edit-releaseYear').val('');
    $('#edit-director').val('');
    $('#edit-rating').val('');
    $('#edit-dvdId').val('');
	
    $('#editDvdFormDiv').hide();
    $('#dvdTable').show();
}

function deleteContact(contactId) {
    $.ajax ({
        type: 'DELETE',
        url: "http://localhost:50215/contact/" + contactId,
        success: function (status) {
            loadContacts();
        }
    });
}


