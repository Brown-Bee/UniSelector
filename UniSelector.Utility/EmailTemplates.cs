using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniSelector.Utility
{
    public static class EmailTemplates
    {
        public static string GetApplicationResponseEmail(string studentName, string universityName,
            string facultyName, string majorName, string status, string? feedback)
        {
            // The status parameter can be either "Accepted" or "Rejected"
            string statusColor = status == "Accepted" ? "#28a745" : "#dc3545"; // Green for Accept, Red for Reject
            string statusIcon = status == "Accepted" ? "✓" : "×"; // Checkmark for Accept, X for Reject

            return $@"
            <!DOCTYPE html>
            <html>
                <head>
                    <meta charset='UTF-8'>
                    <style>
                        body {{ 
                            font-family: Arial, sans-serif; 
                            margin: 0;
                            padding: 0;
                        }}
                        .header {{ 
                            background-color: {statusColor}; 
                            color: white; 
                            padding: 20px; 
                            text-align: center; 
                        }}
                        .content {{ 
                            padding: 20px; 
                            line-height: 1.6;
                        }}
                        .status-badge {{ 
                            background-color: {statusColor}; 
                            color: white; 
                            padding: 5px 15px;
                            border-radius: 15px;
                            display: inline-block;
                        }}
                        .details {{
                            background-color: #f8f9fa;
                            padding: 15px;
                            border-radius: 5px;
                            margin: 15px 0;
                        }}
                    </style>
                </head>
                <body>
                    <div class='header'>
                        <h1>{statusIcon} Application {status}</h1>
                    </div>
                    <div class='content'>
                        <p>Dear {studentName},</p>
                        
                        <p>Your application to {universityName} for {majorName} in {facultyName} has been 
                            <span class='status-badge'>{status}</span>
                        </p>
                        
                        {(string.IsNullOrEmpty(feedback) ? "" : $@"
                            <div class='details'>
                                <strong>Feedback from the university:</strong><br>
                                {feedback}
                            </div>
                        ")}
                        
                        <div class='details'>
                            <strong>Application Details:</strong>
                            <ul>
                                <li>University: {universityName}</li>
                                <li>Faculty: {facultyName}</li>
                                <li>Major: {majorName}</li>
                                <li>Status: {status}</li>
                            </ul>
                        </div>
                        
                        <p>{(status == "Accepted" ?
                            "Congratulations! Please check your university email for further instructions." :
                            "We encourage you to explore other opportunities that match your qualifications.")}</p>
                        
                        <p>Best regards,<br>UniSelector Team</p>
                    </div>
                </body>
            </html>";
        }
    }
}
