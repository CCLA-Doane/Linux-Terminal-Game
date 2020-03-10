using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class AnimateUpdate
{
    private static string[] wheel = { "-", "\\", "|", "/" };

    private int wheelState;
    private int wheelIndex;

    private StringBuilder progressBar;

    private int sectionsRemaining;
    private int currSectionIndex;

    public AnimateUpdate(int totalDownloadSections)
    {
        progressBar = new StringBuilder();

        this.sectionsRemaining = totalDownloadSections;

        progressBar.Append('_', totalDownloadSections);
        progressBar.AppendLine();

        currSectionIndex = progressBar.Length;

        // Progress bar is empty (blank spaces) initially
        progressBar.Append(' ', totalDownloadSections + 1);

        wheelIndex = progressBar.Length;
        progressBar.AppendLine(wheel[wheelState]);

        progressBar.Append('=', totalDownloadSections);
    }

    public string GetUpdatedProgressBar()
    {
        if (!IsProgressComplete())
        {
            progressBar.Replace(' ', '#', currSectionIndex, 1);
            currSectionIndex += 1;

            int nextWheelState = (wheelState + 1) % wheel.Length;
            progressBar.Replace(wheel[wheelState], wheel[nextWheelState], wheelIndex, 1);
            wheelState = nextWheelState;

            sectionsRemaining -= 1;
        }
        return progressBar.ToString();
    }

    public bool IsProgressComplete()
    {
        return sectionsRemaining == 0;
    }
}
