using System.Windows.Input;
using System.Windows.Input.StylusPlugIns;
using UnityEngine;

public class StylusTest : StylusPlugIn
    {
        StylusPointCollection collectedPoints;
        int currentStylus = -1;

        protected override void OnStylusDown(RawStylusInput rawStylusInput)
        {
            // Run the base class before modifying the data
            base.OnStylusDown(rawStylusInput);
            Debug.Log("Stylus Down");
            /*
            if (currentStylus == -1)
            {
                StylusPointCollection pointsFromEvent = rawStylusInput.GetStylusPoints();

                // Create an emtpy StylusPointCollection to contain the filtered
                // points.
                collectedPoints = new StylusPointCollection(pointsFromEvent.Description);

                // Restrict the stylus input and add the filtered 
                // points to collectedPoints. 
                StylusPointCollection points = FilterPackets(pointsFromEvent);
                rawStylusInput.SetStylusPoints(points);
                collectedPoints.Add(points);

                currentStylus = rawStylusInput.StylusDeviceId;
            }
            */
        }

        protected override void OnStylusMove(RawStylusInput rawStylusInput)
        {
            // Run the base class before modifying the data
            base.OnStylusMove(rawStylusInput);

            if (currentStylus == rawStylusInput.StylusDeviceId)
            {
                StylusPointCollection pointsFromEvent = rawStylusInput.GetStylusPoints();

                // Restrict the stylus input and add the filtered 
                // points to collectedPoints. 
                StylusPointCollection points = FilterPackets(pointsFromEvent);
                rawStylusInput.SetStylusPoints(points);
                collectedPoints.Add(points);
            }
        }

        protected override void OnStylusUp(RawStylusInput rawStylusInput)
        {
            // Run the base class before modifying the data
            base.OnStylusUp(rawStylusInput);

            Debug.Log("Stylus Up");

        if (currentStylus == rawStylusInput.StylusDeviceId)
            {
                StylusPointCollection pointsFromEvent = rawStylusInput.GetStylusPoints();

                // Restrict the stylus input and add the filtered 
                // points to collectedPoints. 
                StylusPointCollection points = FilterPackets(pointsFromEvent);
                rawStylusInput.SetStylusPoints(points);
                collectedPoints.Add(points);

                // Subscribe to the OnStylusUpProcessed method.
                rawStylusInput.NotifyWhenProcessed(collectedPoints);

                currentStylus = -1;
            }
        }

        private StylusPointCollection FilterPackets(StylusPointCollection stylusPoints)
        {
            // Modify the (X,Y) data to move the points 
            // inside the acceptable input area, if necessary
            for (int i = 0; i < stylusPoints.Count; i++)
            {
                StylusPoint sp = stylusPoints[i];
                if (sp.X < 50) sp.X = 50;
                if (sp.X > 250) sp.X = 250;
                if (sp.Y < 50) sp.Y = 50;
                if (sp.Y > 250) sp.Y = 250;
                stylusPoints[i] = sp;
            }

            // Return the modified StylusPoints.
            return stylusPoints;
        }

        // This is called on the application thread.  
        protected override void OnStylusUpProcessed(object callbackData, bool targetVerified)
        {
            // Check that the element actually receive the OnStylusUp input.
            if (targetVerified)
            {
                StylusPointCollection strokePoints = callbackData as StylusPointCollection;

                if (strokePoints == null)
                {
                    return;
                }

            }

        }
    }
