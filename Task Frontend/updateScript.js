const urlParams = new URLSearchParams(window.location.search);
const employeeId = urlParams.get("employeeId");

function UpdateEmployee(employeeData) {
  $.ajax({
    url: "https://localhost:7248/api/v1/employee/update",
    method: "PUT",
    contentType: "application/json",
    data: JSON.stringify(employeeData),
    success: (response) => {
      alert("The Employee Updated Successfully");
      window.location.href = "/index.html";
    },
    error: (error) => {
      alert("Failed to add employee!");
    },
  });
}

$.ajax({
  url: `https://localhost:7248/api/v1/employee/${employeeId}`,
  method: "GET",
  success: (response) => {
    $("#first").val(response.firstName);
    $("#last").val(response.lastName);
    $("#jobTitle").val(response.jobTitle);
    $("#level").val(response.level);
    $("#header").text(`Update Employee Info Id=${employeeId}`);
  },
  error: (error) => {},
});

$("#update-btn").click(() => {
  const firstName = $("#first").val();
  const lastName = $("#last").val();
  const jobTitle = $("#jobTitle").val();
  const level = $("#level").val();

  if (!firstName || !lastName || !jobTitle || !level) {
    alert("You must fill all information!");
    return;
  }

  const employeeData = {
    employeeId: employeeId,
    firstName,
    lastName,
    jobTitle,
    level,
  };

  console.log(employeeData);

  UpdateEmployee(employeeData);
});
