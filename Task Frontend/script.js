let total = 0;

function handleDeleteEmployee(employeeId) {
  console.log(employeeId);

  $.ajax({
    url: `https://localhost:7248/api/v1/employee/${employeeId}`,
    method: "DELETE",
    success: (response) => {
      $(`#employee-row-${employeeId}`).hide();
    },
    error: (error) => {
      alert("Failed to delete this employee!");
    },
  });

  --total;
  $("#total").text(`Total employees: ${total}`);
}

function SetEmployeeInTheTable(employee) {
  $("#container").append(
    `
         <h1>Your System Employees</h1>
         <button id="add-btn">Add New Employee</button>
         <table id="empTable" border=3>
            <tr>
                <th>employeId</th>
                <th>employeeName</th>
                <th>jobTitle</th>
                <th>level</th>
                <th>dateOfJoined</th>
                <th>deleteAction</th>
                <th>updateAction</th>
            </tr>
            <tfoot>
                <tr>
                    <td id="total" colspan="2">Total employees: ${employee.length}</td>
                </tr>
            </tfoot>
        </table>
        `
  );

  for (let index = 0; index < employee.length; index++) {
    $("#empTable").append(
      `
                    <tr id="employee-row-${employee[index].id}">
                        <td>${employee[index].id}</td>
                        <td>${
                          employee[index].firstName +
                          " " +
                          employee[index].lastName
                        }</td>
                        <td>${employee[index].jobTitle}</td>
                        <td>${employee[index].level}</td>
                        <td>${employee[index].dateOfJoined}</td>
                        <td>
                         <button class='delete-btn' data-employeeid='${
                           employee[index].id
                         }'>
                           delete
                         </button>
                        </td>
                        <td>
                         <button class='update-btn' data-employeeid='${
                           employee[index].id
                         }'>
                           update
                         </button>
                        </td>
                    </tr>
                `
    );
  }

  total = employee.length;
}

$.ajax({
  url: "https://localhost:7248/api/v1/employee/all",
  method: "GET",
  success: (response) => {
    $("#loader").hide();
    SetEmployeeInTheTable(response);
  },
  error: (error) => {
    console.log(error);
    $("body").append(`<p>${error}</p>`);
  },
});

$(document).on("click", ".delete-btn", function () {
  if (!window.confirm("Are you sure to delete this employee?")) {
    return;
  }
  const employeeid = $(this).data("employeeid");
  handleDeleteEmployee(employeeid);
});

$(document).on("click", ".update-btn", function () {
  const employeeid = $(this).data("employeeid");
  window.location.href = `UpdateEmployee.html?employeeId=${employeeid}`;
});

$(document).on("click", "#add-btn", function () {
  window.location.href = `AddEmployee.html`;
});
