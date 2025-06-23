function AddNewEmployee(employeeData) {
  $.ajax({
    url: "https://localhost:7248/api/v1/employee/add",
    method: "POST",
    contentType: "application/json",
    data: JSON.stringify(employeeData),
    success: (response) => {
      alert("The Employee Added Successfully");
      window.location.href = "/index.html";
    },
    error: (error) => {
      alert("Failed to add employee!");
    },
  });
}

$("#add-btn").click(() => {
  const firstName = $("#first").val();
  const lastName = $("#last").val();
  const jobTitle = $("#jobTitle").val();
  const level = $("#level").val();

  if (!firstName || !lastName || !jobTitle || !level) {
    alert("You must fill all information!");
    return;
  }

  const employeeData = {
    firstName,
    lastName,
    jobTitle,
    level,
  };

  AddNewEmployee(employeeData);
});
