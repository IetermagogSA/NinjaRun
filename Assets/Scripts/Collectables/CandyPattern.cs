using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using UnityEngine;

public class CandyPattern : MonoBehaviour
{

    //public GameObject[] candies;

    private List<GameObject> createdCandies;

    float startingX = 1f;

    float floatStrength = 0.01f;

    enum CandyColours
    {
        [Description("Prefabs/Collectables/Candy/CandyBlue")]
        CandyBlue = 1,
        [Description("Prefabs/Collectables/Candy/CandyGreen")]
        CandyGreen = 2,
        [Description("Prefabs/Collectables/Candy/CandyOrange")]
        CandyOrange = 3,
        [Description("Prefabs/Collectables/Candy/CandyPurple")]
        CandyPurple = 4,
        [Description("Prefabs/Collectables/Candy/CandyRed")]
        CandyRed = 5,
        [Description("Prefabs/Collectables/Candy/CandyTeal")]
        CandyTeal = 6,
        [Description("Prefabs/Collectables/Candy/CandyYellow")]
        CandyYellow = 7
    };

    private void Awake()
    {

        createdCandies = new List<GameObject>();
        startingX = 1f;

        // Create and position the candies
        CreateAndPositionCandies();
    }

    private void CreateAndPositionCandies()
    {
        // Spawn the candies
        int candyAmount = UnityEngine.Random.Range(6, 11); // 10 will not be included
        int candyColourNumber = UnityEngine.Random.Range(1, 8); // 7 is excluded

        for (int i = 0; i < candyAmount; i++)
        {
            Vector3 temp = transform.position;
            temp.x += startingX;

            GameObject myNewInstance = Instantiate(Resources.Load(GetEnumDescription((CandyColours)candyColourNumber)),temp, Quaternion.Euler(new Vector3(45, 0, 0))) as GameObject;
            //GameObject myNewInstance = (GameObject)Instantiate(candies[i], temp, candies[i].transform.rotation);
            createdCandies.Add(myNewInstance);

            startingX += 1f;
        }


        // Position them
        for (int i = 0; i < createdCandies.Count; i++)
        {
            if (i % 2 == 0)
            {
                // Move Y
                Vector3 tempY = createdCandies[i].transform.localPosition;
                tempY.y += 0.5f;
                createdCandies[i].transform.localPosition = tempY;
            }
        }
    }

    public static string GetEnumDescription(Enum value)
    {
        FieldInfo fi = value.GetType().GetField(value.ToString());

        DescriptionAttribute[] attributes =
            (DescriptionAttribute[])fi.GetCustomAttributes(
            typeof(DescriptionAttribute),
            false);

        if (attributes != null &&
            attributes.Length > 0)
            return attributes[0].Description;
        else
            return value.ToString();
    }

    private void FixedUpdate()
    {
        // This will make the candies move up and down
        // Method 1: Move all candies in sequence
        for (int i = 0; i < createdCandies.Count; i++)
        {
            float originalY = 0;

            originalY = createdCandies[i].transform.localPosition.y;

            createdCandies[i].transform.localPosition = new Vector3(createdCandies[i].transform.localPosition.x,
                                                                    originalY + ((float)System.Math.Sin(Time.time) * floatStrength),
                                                                    createdCandies[i].transform.localPosition.z);
        }

        //// Method 2: Move line 1 and 2 away from each other, then back together
        //for (int i = 0; i < createdCandies.Count; i++)
        //{
        //    float originalY = 0;

        //    originalY = createdCandies[i].transform.localPosition.y;

        //    if (i % 2 == 0)
        //    {
        //    createdCandies[i].transform.localPosition = new Vector3(createdCandies[i].transform.localPosition.x,
        //                                                                originalY + ((float)System.Math.Sin(Time.time) * floatStrength),
        //                                                                createdCandies[i].transform.localPosition.z);
        //    }
        //    else
        //    {
        //    createdCandies[i].transform.localPosition = new Vector3(createdCandies[i].transform.localPosition.x,
        //                                                                originalY - ((float)System.Math.Sin(Time.time) * floatStrength),
        //                                                                createdCandies[i].transform.localPosition.z);
        //    }
        //}
    }
}
