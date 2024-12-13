$(document).ready(function() {
    let filterTimeout;
    function getFilterValues() {
        return {
            universityType: $('#universityType').val(),
            faculty: $('#faculty').val(),
            major: $('#major').val(),
            minimumGrade: $('#minGrade').val(),
            ieltsScore: $('#minIELTS').val(),
            toeflScore: $('#minTOEFL').val(),
            highSchoolPath: $('#highSchoolPath').val(),
            minPrice: $('#minPrice').val(),
            maxPrice: $('#maxPrice').val(),
            maxRank: $('#maxRank').val()
            studyDuration: $('#studyDuration').val(),
            requiresAptitudeTest: $('#requiresAptitudeTest').val()
        };
    }

    function updateResults(universities) {
        const resultsContainer = $('#uni-grid');
        resultsContainer.empty();

        universities.forEach(university => {
            const universityCard = `
            <div class="col-lg-3 col-sm-6 mb-4">
                <div class="card h-100 border-0 shadow rounded-3 overflow-hidden university-card">
                    <div class="position-relative">
                        <img src="${university.ImageUrl}"
                             class="card-img-top university-image"
                             alt="${university.Name}" />
                        <div class="position-absolute top-0 end-0 p-2">
                            <span class="badge bg-primary">${university.type}</span>
                        </div>
                    </div>
                    <div class="card-body p-3">
                        <h5 class="card-title text-center mb-3">${university.Name}</h5>
                        <div class="d-flex justify-content-between align-items-center mb-3">
                            <div class="d-flex align-items-center">
                                <i class="bi bi-geo-alt text-primary me-2"></i>
                                <span>${university.location}</span>
                            </div>
                            <div class="d-flex align-items-center">
                                <i class="bi bi-trophy text-warning me-2"></i>
                                <span>#${university.KuwaitRank}</span>
                            </div>
                        </div>
                        <a href="/User/Home/UniDetails/universityId?universityId=${university.Id}"
                           class="btn btn-primary w-100">
                            <i class="bi bi-info-circle me-2"></i>Details
                        </a>
                    </div>
                </div>
            </div>
        `;
            resultsContainer.append(universityCard);
        });

        // If no results found
        if (universities.length === 0) {
            resultsContainer.append(`
            <div class="col-12 text-center py-5">
                <h6 class="text-muted">No universities found matching your criteria</h6>
            </div>
        `);
        }
    }
    function performFilter() {
        const filterData = getFilterValues();
        console.log(filterData);
        $.ajax({
            url: '/User/Home/FilterUniversities',
            type: 'GET',
            data: filterData,
            success: function (data) {
                console.log(data);
                updateResults(data);
            },
            error: function (xhr, status, error) {
                console.error('Filter failed:', error);
                // Show error message to user
                $('.section-container .row').html(`
                    <div class="col-12 text-center py-5">
                        <h6 class="text-danger">Error loading universities. Please try again.</h6>
                    </div>
                `);
            }
        })
    }

    // Populate user data if available
    function populateUserFilters() {
        const currentUser = @Json.Serialize(ViewBag.CurrentUser); // Get user data

        if (currentUser) {
            // Set High School Path
            if (currentUser.HighSchoolType) {
                $('#highSchoolPath').val(currentUser.HighSchoolType);
            }

            // Set Grade
            if (currentUser.Grade) {
                $('#minGrade').val(currentUser.Grade);
            }

            // Set IELTS Score
            if (currentUser.IELTS) {
                $('#minIELTS').val(currentUser.IELTS);
            }

            // Set TOEFL Score
            if (currentUser.TOEFL) {
                $('#minTOEFL').val(currentUser.TOEFL);
            }

            // Set Aptitude Test
            if (currentUser.HasAptitudeTest) {
                $('#requiresAptitudeTest').val(currentUser.HasAptitudeTest.toString());
            }

            // Trigger filter update after populating
            performFilter();
        }
    }

    // Call this function when page loads
    populateUserFilters();

    // Event handler for all filter inputs
    $('.filter-input').on('input change', function() {
        clearTimeout(filterTimeout);
        filterTimeout = setTimeout(performFilter, 100);
    });

    // Clear all filters
    $('#clearAll').click(function() {
        // Clear text inputs and number inputs
        $('input[type="text"], input[type="number"]').val('');

        // Reset select elements to their first option
        $('select').val($('select option:first').val());

        // If you have any custom inputs or elements that need special handling
        $('#minPrice, #maxPrice').val('');
        $('#minGrade').val('');
        $('#minIELTS').val('');
        $('#minTOEFL').val('');

        // Trigger the filter update after clearing
        performFilter();
    });

    // Apply filters button click
    $('#applyFilters').click(function() {
        performFilter();
    });

    // Initial load
    performFilter();
});