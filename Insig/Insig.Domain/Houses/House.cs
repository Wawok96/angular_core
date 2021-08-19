﻿using EnsureThat;
using Insig.Common.Exceptions;
using Insig.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insig.Domain.Houses
{
    public class House : AuditableEntity
    {
        public House(string name, double sizeInMeters, bool singleFloor)
        {
            EnsureThatNameIsCorrect(name);
            EnsureThatSizeIsCorrect(sizeInMeters);

            Name = name;
            SizeInMeters = sizeInMeters;
            SingleFloor = singleFloor;
            Deleted = false;
        }

        public int Id { get; }

        public string Name { get; private set; }
        public double SizeInMeters { get; private set; }
        public bool SingleFloor { get; private set; }
        public bool Deleted { get; set; }

        public void UpdateFields(House house)
        {
            EnsureThatNameIsCorrect(house.Name);
            EnsureThatSizeIsCorrect(house.SizeInMeters);
            Name = house.Name;
            SizeInMeters = house.SizeInMeters;
            SingleFloor = house.SingleFloor;
        }

        private void EnsureThatNameIsCorrect(string name)
        {
            EnsureArg.IsNotNullOrWhiteSpace(name, nameof(name));
        }
        private void EnsureThatSizeIsCorrect(double size)
        {
            if (size == 0)
            {
                throw new DomainException($"House value with size: {size} is not allowed.");
            }
        }
        
    }
}