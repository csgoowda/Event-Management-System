// ==========================================================================
// Event Management System - In-Memory JavaScript Database & Controller Twin
// ==========================================================================

// 1. DATABASE STATE
const Database = {
    users: [],
    events: [],
    participants: [],
    registrations: [],
    currentUser: null,
    currentRole: null
};

function saveDatabase() {
    localStorage.setItem("ems_db", JSON.stringify({
        users: Database.users,
        events: Database.events,
        participants: Database.participants,
        registrations: Database.registrations
    }));
}

// 2. INITIALIZE PRE-POPULATED SAMPLE DATA (Mirroring Database.cs in C#)
function initializeSampleData() {
    const saved = localStorage.getItem("ems_db");
    if (saved) {
        const data = JSON.parse(saved);
        Database.users = data.users || [];
        Database.events = data.events || [];
        Database.participants = data.participants || [];
        Database.registrations = data.registrations || [];
        return;
    }

    Database.users = [
        { username: "admin", password: "admin123" },
        { username: "rahul", password: "rahul123" },
        { username: "priya", password: "priya123" },
        { username: "amit", password: "amit123" }
    ];

    Database.events = [
        { eventId: 101, eventName: "National Tech Symposium", eventDate: "2026-09-15", venue: "Main Seminar Hall", type: "Free" },
        { eventId: 102, eventName: "CodeCraft Hackathon", eventDate: "2026-10-22", venue: "Computer Lab 3", type: "Paid" },
        { eventId: 103, eventName: "Web Development Workshop", eventDate: "2026-11-05", venue: "CSE Seminar Hall", type: "Free" },
        { eventId: 104, eventName: "AI & Machine Learning Seminar", eventDate: "2026-12-12", venue: "Auditorium 2", type: "Paid" }
    ];

    Database.participants = [
        { participantId: 1, name: "Rahul Sharma", phoneNumber: "9876543210" },
        { participantId: 2, name: "Priya Patel", phoneNumber: "8765432109" },
        { participantId: 3, name: "Amit Verma", phoneNumber: "7654321098" },
        { participantId: 4, name: "Karan Singh", phoneNumber: "6543210987" }
    ];

    Database.registrations = [
        { registrationId: 1, username: "rahul", eventName: "National Tech Symposium", status: "Approved" },
        { registrationId: 2, username: "rahul", eventName: "CodeCraft Hackathon", status: "Pending" },
        { registrationId: 3, username: "priya", eventName: "Web Development Workshop", status: "Approved" },
        { registrationId: 4, username: "amit", eventName: "AI & Machine Learning Seminar", status: "Rejected" }
    ];
    saveDatabase();
}

// 3. GENERIC SEARCH FILTER (Mirroring Database.FindItems<T> in C#)
function findItems(array, predicate) {
    const results = [];
    for (let i = 0; i < array.length; i++) {
        if (predicate(array[i])) {
            results.push(array[i]);
        }
    }
    return results;
}

// 4. ROUTING & DASHBOARD NAVIGATION
function switchPanel(panelId, title) {
    // Hide all panels
    const panels = document.querySelectorAll(".dashboard-panel");
    panels.forEach(p => p.classList.remove("active"));

    // Show selected panel
    const targetPanel = document.getElementById(panelId);
    if (targetPanel) {
        targetPanel.classList.add("active");
    }

    // Update Top bar Header Title
    document.getElementById("active-panel-title").innerText = title;

    // Update active class in sidebar menu
    const menuItems = document.querySelectorAll(".menu-item");
    menuItems.forEach(item => {
        if (item.getAttribute("data-target") === panelId) {
            item.classList.add("active");
        } else {
            item.classList.remove("active");
        }
    });

    // Refresh dynamic data of panels upon loading
    if (panelId === "reports-panel") renderReports();
    else if (panelId === "events-panel") renderEventsTable();
    else if (panelId === "participants-panel") renderParticipantsTable();
    else if (panelId === "registrations-panel") renderAdminRegsTable();
    else if (panelId === "users-panel") renderUsersTable();
    else if (panelId === "user-explore-panel") renderUserExploreTable();
    else if (panelId === "user-regs-panel") renderUserRegsTable();
    else if (panelId === "profile-panel") loadUserProfile();
    // Special panels handled dynamically
}

// Setup Event Handlers for Sidebar Menu Click Actions
function setupNavigation() {
    const menuItems = document.querySelectorAll(".menu-item[data-target]");
    menuItems.forEach(item => {
        item.addEventListener("click", (e) => {
            e.preventDefault();
            const panelId = item.getAttribute("data-target");
            const title = item.innerText.trim();
            switchPanel(panelId, title);
        });
    });
}

// ==========================================================================
// 5. RENDERING OPERATIONS (DATA BINDING)
// ==========================================================================

// Renders Statistics Dashboard Cards
function renderReports() {
    document.getElementById("stat-users-count").innerText = Database.users.length;
    document.getElementById("stat-events-count").innerText = Database.events.length;
    document.getElementById("stat-parts-count").innerText = Database.participants.length;
    document.getElementById("stat-regs-count").innerText = Database.registrations.length;
}

function renderEventsTable() {
    const tbody = document.getElementById("events-table-body");
    tbody.innerHTML = "";
    
    Database.events.forEach(ev => {
        const typeClass = ev.type === "Paid" ? "badge-accent" : "badge-approved";
        const tr = document.createElement("tr");
        tr.innerHTML = `
            <td>${ev.eventId}</td>
            <td><strong>${ev.eventName}</strong></td>
            <td>${ev.eventDate}</td>
            <td>${ev.venue}</td>
            <td><span class="badge ${typeClass}">${ev.type || 'Free'}</span></td>
            <td class="table-actions">
                <button class="btn btn-primary btn-tbl" onclick="editEvent(${ev.eventId})"><i class="fa-solid fa-pen"></i> Edit</button>
                <button class="btn btn-danger btn-tbl" onclick="deleteEvent(${ev.eventId})"><i class="fa-solid fa-trash"></i> Delete</button>
            </td>
        `;
        tbody.appendChild(tr);
    });
}

// Render Admin Participants Table
function renderParticipantsTable() {
    const tbody = document.getElementById("parts-table-body");
    tbody.innerHTML = "";
    
    Database.participants.forEach(p => {
        const tr = document.createElement("tr");
        tr.innerHTML = `
            <td>${p.participantId}</td>
            <td><strong>${p.name}</strong></td>
            <td>${p.phoneNumber}</td>
            <td class="table-actions">
                <button class="btn btn-primary btn-tbl" onclick="editParticipant(${p.participantId})"><i class="fa-solid fa-pen"></i> Edit</button>
                <button class="btn btn-danger btn-tbl" onclick="deleteParticipant(${p.participantId})"><i class="fa-solid fa-trash"></i> Delete</button>
            </td>
        `;
        tbody.appendChild(tr);
    });
}

// Render Admin Registration Approvals Table
function renderAdminRegsTable() {
    const tbody = document.getElementById("admin-regs-table-body");
    tbody.innerHTML = "";
    
    Database.registrations.forEach(r => {
        const tr = document.createElement("tr");
        let badgeClass = "badge-pending";
        if (r.status === "Approved") badgeClass = "badge-approved";
        else if (r.status === "Rejected") badgeClass = "badge-rejected";

        tr.innerHTML = `
            <td>${r.registrationId}</td>
            <td><strong>${r.username}</strong></td>
            <td>${r.eventName}</td>
            <td><span class="badge ${badgeClass}">${r.status}</span></td>
            <td class="table-actions">
                <button class="btn btn-success btn-tbl" onclick="updateRegStatus(${r.registrationId}, 'Approved')"><i class="fa-solid fa-check"></i> Approve</button>
                <button class="btn btn-danger btn-tbl" onclick="updateRegStatus(${r.registrationId}, 'Rejected')"><i class="fa-solid fa-xmark"></i> Reject</button>
                <button class="btn btn-light btn-tbl" onclick="deleteReg(${r.registrationId})"><i class="fa-solid fa-trash-can"></i> Delete</button>
            </td>
        `;
        tbody.appendChild(tr);
    });
}

// Render Admin Users Management Directory
function renderUsersTable() {
    const tbody = document.getElementById("users-table-body");
    tbody.innerHTML = "";
    
    Database.users.forEach(u => {
        const tr = document.createElement("tr");
        const isSuper = u.username.toLowerCase() === "admin";
        
        tr.innerHTML = `
            <td><strong>${u.username}</strong></td>
            <td><code>${u.password}</code></td>
            <td><span class="badge ${isSuper ? 'badge-approved' : 'badge-accent'}">${isSuper ? 'Super Admin' : 'Student User'}</span></td>
            <td>
                ${isSuper ? '<em>System Root</em>' : `<button class="btn btn-danger btn-tbl" onclick="deleteUser('${u.username}')"><i class="fa-solid fa-user-minus"></i> Delete Account</button>`}
            </td>
        `;
        tbody.appendChild(tr);
    });
}

// Render Student User Events Explore Grid
function renderUserExploreTable(query = "") {
    const tbody = document.getElementById("user-events-table-body");
    tbody.innerHTML = "";

    // Apply generic filter simulation if search text is provided
    let listToRender = Database.events;
    if (query) {
        listToRender = findItems(Database.events, ev => 
            ev.eventName.toLowerCase().includes(query.toLowerCase()) ||
            ev.venue.toLowerCase().includes(query.toLowerCase())
        );
    }

    listToRender.forEach(ev => {
        const typeClass = ev.type === "Paid" ? "badge-accent" : "badge-approved";
        const tr = document.createElement("tr");
        tr.innerHTML = `
            <td><strong>${ev.eventName}</strong></td>
            <td>${ev.eventDate}</td>
            <td>${ev.venue}</td>
            <td><span class="badge ${typeClass}">${ev.type || 'Free'}</span></td>
            <td>
                <button class="btn btn-accent btn-tbl" onclick="openRegistrationForm('${ev.eventName}')"><i class="fa-solid fa-file-signature"></i> Register</button>
            </td>
        `;
        tbody.appendChild(tr);
    });
}

// Render My Registrations Panel (User Mode)
function renderUserRegsTable() {
    const tbody = document.getElementById("user-regs-table-body");
    tbody.innerHTML = "";

    // Use generics search helper to grab only current user's registration forms
    const userRegs = findItems(Database.registrations, r => r.username === Database.currentUser);

    userRegs.forEach(r => {
        const tr = document.createElement("tr");
        let badgeClass = "badge-pending";
        if (r.status === "Approved") badgeClass = "badge-approved";
        else if (r.status === "Rejected") badgeClass = "badge-rejected";

        tr.innerHTML = `
            <td>${r.registrationId}</td>
            <td><strong>${r.eventName}</strong></td>
            <td><span class="badge ${badgeClass}">${r.status}</span></td>
        `;
        tbody.appendChild(tr);
    });
}

// Pre-fill profile panel
function loadUserProfile() {
    document.getElementById("profile-username").innerText = Database.currentUser;
    document.getElementById("profile-password-form").reset();
}

// ==========================================================================
// 6. BUSINESS CRUDS AND MUTATION LOGIC
// ==========================================================================

// Event CRUD Actions
window.editEvent = function(id) {
    const ev = Database.events.find(e => e.eventId === id);
    if (ev) {
        document.getElementById("event-id").value = ev.eventId;
        document.getElementById("event-id").disabled = true;
        document.getElementById("event-name").value = ev.eventName;
        document.getElementById("event-date").value = ev.eventDate;
        document.getElementById("event-venue").value = ev.venue;
        document.getElementById("event-type").value = ev.type || "Free";
        document.getElementById("event-amount").value = ev.amount || "";
        document.getElementById("event-amount-group").style.display = ev.type === "Paid" ? "block" : "none";
        
        document.getElementById("event-edit-mode").value = "true";
        document.getElementById("btn-save-event").innerText = "Update Event";
    }
};

window.deleteEvent = function(id) {
    const evIndex = Database.events.findIndex(e => e.eventId === id);
    if (evIndex !== -1) {
        const ev = Database.events[evIndex];
        if (confirm(`Are you sure you want to delete event '${ev.eventName}'?`)) {
            // Cascade delete: clean registrations for this event
            Database.registrations = Database.registrations.filter(r => r.eventName !== ev.eventName);
            
            // Delete event
            Database.events.splice(evIndex, 1);
            saveDatabase();
            alert("Event deleted successfully!");
            renderEventsTable();
            renderReports();
        }
    }
};

// Participant CRUD Actions
window.editParticipant = function(id) {
    const p = Database.participants.find(part => part.participantId === id);
    if (p) {
        document.getElementById("part-id").value = p.participantId;
        document.getElementById("part-id").disabled = true;
        document.getElementById("part-name").value = p.name;
        document.getElementById("part-phone").value = p.phoneNumber;
        
        document.getElementById("part-edit-mode").value = "true";
        document.getElementById("btn-save-part").innerText = "Update Participant";
    }
};

window.deleteParticipant = function(id) {
    const pIndex = Database.participants.findIndex(part => part.participantId === id);
    if (pIndex !== -1) {
        const p = Database.participants[pIndex];
        if (confirm(`Are you sure you want to delete participant '${p.name}'?`)) {
            Database.participants.splice(pIndex, 1);
            saveDatabase();
            alert("Participant removed from directory.");
            renderParticipantsTable();
            renderReports();
        }
    }
};

// Registration Actions (Approve/Reject/Delete)
window.updateRegStatus = function(id, status) {
    const reg = Database.registrations.find(r => r.registrationId === id);
    if (reg) {
        reg.status = status;
        saveDatabase();
        alert(`Registration status updated to '${status}'.`);
        renderAdminRegsTable();
        renderReports();
    }
};

window.deleteReg = function(id) {
    const idx = Database.registrations.findIndex(r => r.registrationId === id);
    if (idx !== -1) {
        if (confirm(`Delete registration ID ${id}?`)) {
            Database.registrations.splice(idx, 1);
            saveDatabase();
            alert("Registration record deleted.");
            renderAdminRegsTable();
            renderReports();
        }
    }
};

// Delete User Account
window.deleteUser = function(username) {
    if (username.toLowerCase() === "admin") {
        alert("The primary administrator account cannot be deleted.");
        return;
    }
    
    if (confirm(`Permanently delete user account '${username}'?`)) {
        // Cascade delete registrations
        Database.registrations = Database.registrations.filter(r => r.username !== username);
        // Cascade delete participant profile
        Database.participants = Database.participants.filter(p => p.name.toLowerCase() !== username.toLowerCase());
        // Delete user
        Database.users = Database.users.filter(u => u.username !== username);
        
        saveDatabase();
        alert("User account and related event records deleted successfully.");
        renderUsersTable();
        renderReports();
    }
};

// NEW FLOW: User Registers for Event
window.openRegistrationForm = function(eventName) {
    // Check duplicate enrollment
    const alreadyEnrolled = Database.registrations.some(r => r.username === Database.currentUser && r.eventName === eventName);
    if (alreadyEnrolled) {
        alert(`You have already registered for '${eventName}'.`);
        return;
    }
    
    const ev = Database.events.find(e => e.eventName === eventName);
    if (!ev) return;
    
    document.getElementById("reg-ev-name").innerText = ev.eventName;
    document.getElementById("reg-ev-type").innerText = ev.type || "Free";
    
    if (ev.type === "Paid") {
        document.getElementById("reg-ev-amount-display").style.display = "block";
        document.getElementById("reg-ev-amount").innerText = ev.amount || "0";
    } else {
        document.getElementById("reg-ev-amount-display").style.display = "none";
    }
    
    // Auto-fill existing details if available
    const part = Database.participants.find(p => p.name.toLowerCase() === Database.currentUser.toLowerCase());
    if (part) {
        document.getElementById("stud-name").value = part.name !== "N/A" ? part.name : Database.currentUser;
        document.getElementById("stud-phone").value = part.phoneNumber !== "N/A" ? part.phoneNumber : "";
    }
    
    // Toggle button style based on Free/Paid
    const btn = document.getElementById("btn-submit-reg");
    if (ev.type === "Paid") {
        btn.innerText = "Proceed to Payment";
        btn.className = "btn btn-accent btn-block";
    } else {
        btn.innerText = "Register for Free";
        btn.className = "btn btn-primary btn-block";
    }

    switchPanel("event-registration-form-panel", "Event Registration Details");
};

window.userRegisterForEvent = function(eventName) {
    const nextId = Database.registrations.length > 0 ? Database.registrations[Database.registrations.length - 1].registrationId + 1 : 1;
    
    const newReg = {
        registrationId: nextId,
        username: Database.currentUser,
        eventName: eventName,
        status: "Pending"
    };

    Database.registrations.push(newReg);
    saveDatabase();
    alert(`Registration submitted for '${eventName}'! Awaiting Admin approval.`);
    switchPanel("user-explore-panel", "Register for Events");
};

// ==========================================================================
// 7. EVENT LISTENER FORMS VALIDATION
// ==========================================================================

function setupFormListeners() {
    // A. LOGIN FORM SUBMIT
    document.getElementById("login-form").addEventListener("submit", (e) => {
        e.preventDefault();
        const role = document.getElementById("login-role").value;
        const user = document.getElementById("login-username").value.trim();
        const pass = document.getElementById("login-password").value;

        try {
            if (!user || !pass) {
                throw new Error("Username and Password are required.");
            }

            if (role === "Admin") {
                if (user === "admin" && pass === "admin123") {
                    Database.currentUser = "admin";
                    Database.currentRole = "Admin";
                } else {
                    throw new Error("Invalid Administrator Credentials.");
                }
            } else {
                const foundUser = Database.users.find(u => u.username.toLowerCase() === user.toLowerCase());
                if (!foundUser) {
                    throw new Error("Username does not exist. Please register first.");
                } else if (foundUser.password !== pass) {
                    throw new Error("Incorrect Password. Please try again.");
                } else {
                    Database.currentUser = foundUser.username;
                    Database.currentRole = "User";
                }
            }

            // SUCCESSFUL LOGIN: Configure Panel Displays
            alert(`Welcome back, ${Database.currentUser}!`);
            
            // Adjust sidebar menu links depending on role
            if (Database.currentRole === "Admin") {
                document.querySelectorAll(".admin-only").forEach(el => el.classList.remove("hide"));
                document.querySelectorAll(".user-only").forEach(el => el.classList.add("hide"));
                document.getElementById("sidebar-logo-text").innerText = "EMS - ADMIN";
                document.getElementById("role-badge-display").innerText = "Admin";
                document.getElementById("role-badge-display").className = "role-badge";
                
                // Route to reports panel
                switchPanel("reports-panel", "Reports & Summary");
            } else {
                document.querySelectorAll(".admin-only").forEach(el => el.classList.add("hide"));
                document.querySelectorAll(".user-only").forEach(el => el.classList.remove("hide"));
                document.getElementById("sidebar-logo-text").innerText = "EMS - STUDENT";
                document.getElementById("role-badge-display").innerText = "Student";
                document.getElementById("role-badge-display").className = "role-badge badge-accent";
                
                // Route to event exploration panel
                switchPanel("user-explore-panel", "Register for Events");
            }

            document.getElementById("username-display").innerText = Database.currentUser;

            // Swap viewports
            document.getElementById("auth-screen").classList.add("hide");
            document.getElementById("dashboard-screen").classList.remove("hide");
            
            // Clear credentials
            document.getElementById("login-form").reset();

        } catch (error) {
            alert(error.message);
        }
    });

    // B. REGISTER FORM SUBMIT
    document.getElementById("register-form").addEventListener("submit", (e) => {
        e.preventDefault();
        const user = document.getElementById("reg-username").value.trim();
        const pass = document.getElementById("reg-password").value;
        const confirmPass = document.getElementById("reg-confirm-password").value;

        try {
            if (!user || !pass || !confirmPass) {
                throw new Error("All fields are required.");
            }
            if (pass !== confirmPass) {
                throw new Error("Passwords do not match.");
            }
            if (user.toLowerCase() === "admin") {
                throw new Error("Username 'admin' is a reserved system credential.");
            }
            const exists = Database.users.some(u => u.username.toLowerCase() === user.toLowerCase());
            if (exists) {
                throw new Error(`Username '${user}' is already taken.`);
            }

            // SUCCESS: Add to User array
            Database.users.push({ username: user, password: pass });
            
            // Auto create matching participant profile
            const nextPartId = Database.participants.length > 0 ? Database.participants[Database.participants.length - 1].participantId + 1 : 1;
            Database.participants.push({
                participantId: nextPartId,
                name: user.charAt(0).toUpperCase() + user.slice(1),
                phoneNumber: "N/A"
            });
            
            saveDatabase();

            alert("Registration completed successfully! You can now log in.");
            
            // Flip back to login card
            document.getElementById("register-view").classList.remove("active");
            document.getElementById("login-view").classList.add("active");
            document.getElementById("register-form").reset();

        } catch (error) {
            alert(error.message);
        }
    });

    // Toggle Login / Register Sub-Views
    document.getElementById("go-to-register").addEventListener("click", (e) => {
        e.preventDefault();
        document.getElementById("login-view").classList.remove("active");
        document.getElementById("register-view").classList.add("active");
    });

    document.getElementById("go-to-login").addEventListener("click", (e) => {
        e.preventDefault();
        document.getElementById("register-view").classList.remove("active");
        document.getElementById("login-view").classList.add("active");
    });

    // C. ADMIN SAVE EVENT
    document.getElementById("event-form").addEventListener("submit", (e) => {
        e.preventDefault();
        const id = parseInt(document.getElementById("event-id").value);
        const name = document.getElementById("event-name").value.trim();
        const date = document.getElementById("event-date").value;
        const venue = document.getElementById("event-venue").value.trim();
        const type = document.getElementById("event-type").value;
        const amount = document.getElementById("event-amount").value;
        const isEdit = document.getElementById("event-edit-mode").value === "true";

        try {
            if (isEdit) {
                const ev = Database.events.find(item => item.eventId === id);
                if (ev) {
                    const oldName = ev.eventName;
                    ev.eventName = name;
                    ev.eventDate = date;
                    ev.venue = venue;
                    ev.type = type;
                    ev.amount = amount;

                    // Sync registration events
                    Database.registrations.forEach(r => {
                        if (r.eventName === oldName) r.eventName = name;
                    });

                    saveDatabase();
                    alert("Event updated successfully!");
                }
            } else {
                // Check duplicate ID
                const exists = Database.events.some(item => item.eventId === id);
                if (exists) {
                    throw new Error(`An event with ID ${id} already exists.`);
                }
                Database.events.push({ eventId: id, eventName: name, eventDate: date, venue: venue, type: type, amount: amount });
                saveDatabase();
                alert("Event scheduled successfully.");
            }

            clearEventForm();
            renderEventsTable();
            renderReports();

        } catch (error) {
            alert(error.message);
        }
    });

    document.getElementById("btn-clear-event").addEventListener("click", clearEventForm);

    function clearEventForm() {
        document.getElementById("event-form").reset();
        document.getElementById("event-id").disabled = false;
        document.getElementById("event-edit-mode").value = "false";
        document.getElementById("event-amount-group").style.display = "none";
        document.getElementById("btn-save-event").innerText = "Add Event";
    }

    // D. ADMIN SAVE PARTICIPANT
    document.getElementById("part-form").addEventListener("submit", (e) => {
        e.preventDefault();
        const id = parseInt(document.getElementById("part-id").value);
        const name = document.getElementById("part-name").value.trim();
        const phone = document.getElementById("part-phone").value.trim();
        const isEdit = document.getElementById("part-edit-mode").value === "true";

        try {
            if (isEdit) {
                const p = Database.participants.find(item => item.participantId === id);
                if (p) {
                    p.name = name;
                    p.phoneNumber = phone;
                    saveDatabase();
                    alert("Participant updated successfully.");
                }
            } else {
                const exists = Database.participants.some(item => item.participantId === id);
                if (exists) {
                    throw new Error(`Participant with ID ${id} already exists.`);
                }
                Database.participants.push({ participantId: id, name: name, phoneNumber: phone });
                saveDatabase();
                alert("Participant registered successfully.");
            }

            clearPartForm();
            renderParticipantsTable();
            renderReports();

        } catch (error) {
            alert(error.message);
        }
    });

    document.getElementById("btn-clear-part").addEventListener("click", clearPartForm);

    function clearPartForm() {
        document.getElementById("part-form").reset();
        document.getElementById("part-id").disabled = false;
        document.getElementById("part-edit-mode").value = "false";
        document.getElementById("btn-save-part").innerText = "Add Participant";
    }

    // E. STUDENT SEARCH EVENTS
    document.getElementById("btn-user-search").addEventListener("click", () => {
        const query = document.getElementById("user-event-search").value.trim();
        renderUserExploreTable(query);
    });

    document.getElementById("btn-user-reset").addEventListener("click", () => {
        document.getElementById("user-event-search").value = "";
        renderUserExploreTable();
    });

    // F. STUDENT CHANGE PASSWORD
    document.getElementById("profile-password-form").addEventListener("submit", (e) => {
        e.preventDefault();
        const currentPass = document.getElementById("profile-current-pass").value;
        const newPass = document.getElementById("profile-new-pass").value;
        const confirmPass = document.getElementById("profile-confirm-pass").value;

        try {
            const userObj = Database.users.find(u => u.username === Database.currentUser);
            if (!userObj) {
                throw new Error("Active session invalid.");
            }
            if (userObj.password !== currentPass) {
                throw new Error("Verification failed: Current password incorrect.");
            }
            if (newPass !== confirmPass) {
                throw new Error("New password fields do not match.");
            }

            // Success
            userObj.password = newPass;
            saveDatabase();
            alert("Security password updated successfully!");
            document.getElementById("profile-password-form").reset();

        } catch (error) {
            alert(error.message);
        }
    });

    // H. NEW REGISTRATION FORM LISTENER
    document.getElementById("event-reg-detail-form")?.addEventListener("submit", (e) => {
        e.preventDefault();
        const evName = document.getElementById("reg-ev-name").innerText;
        const evType = document.getElementById("reg-ev-type").innerText;
        
        // Save participant details back
        const pName = document.getElementById("stud-name").value;
        const pPhone = document.getElementById("stud-phone").value;
        // Optionally save email/college to participant profile here...

        const part = Database.participants.find(p => p.name.toLowerCase() === Database.currentUser.toLowerCase());
        if (part) {
            part.name = pName;
            part.phoneNumber = pPhone;
            saveDatabase();
        }

        if (evType === "Paid") {
            const ev = Database.events.find(e => e.eventName === evName);
            document.getElementById("payment-amount-display").innerText = "Amount Due: ₹" + (ev.amount || "0");
            switchPanel("payment-panel", "Complete Dummy Payment");
        } else {
            userRegisterForEvent(evName);
        }
    });

    // I. DUMMY PAYMENT SUBMIT LISTENER
    document.getElementById("btn-process-payment")?.addEventListener("click", () => {
        const overlay = document.getElementById("payment-success-overlay");
        overlay.style.display = "flex";
        
        setTimeout(() => {
            overlay.style.display = "none";
            const evName = document.getElementById("reg-ev-name").innerText;
            userRegisterForEvent(evName);
        }, 2000);
    });

    // J. PAYMENT TABS LOGIC
    document.querySelectorAll(".pay-tab").forEach(tab => {
        tab.addEventListener("click", () => {
            // Remove active from all tabs and contents
            document.querySelectorAll(".pay-tab").forEach(t => t.classList.remove("active"));
            document.querySelectorAll(".pay-tab-content").forEach(c => c.style.display = "none");
            
            // Add active to clicked tab
            tab.classList.add("active");
            document.getElementById(tab.getAttribute("data-tab")).style.display = "block";
        });
    });

    // G. LOG OUT
    document.getElementById("btn-logout").addEventListener("click", (e) => {
        e.preventDefault();
        if (confirm("Are you sure you want to log out of the session?")) {
            Database.currentUser = null;
            Database.currentRole = null;

            // Flip screens
            document.getElementById("dashboard-screen").classList.add("hide");
            document.getElementById("auth-screen").classList.remove("hide");
            document.getElementById("login-view").classList.add("active");
            document.getElementById("register-view").classList.remove("active");
        }
    });
}

// 8. ON PAGE LOAD
window.addEventListener("DOMContentLoaded", () => {
    initializeSampleData();
    setupNavigation();
    setupFormListeners();
});
